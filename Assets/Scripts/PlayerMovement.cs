using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    private CreateObject Cast;
    public Camera Cam;

    Vector3 velocity;
    public float speed = 12f;
    public float jumpHeight = 3f;
    public float gravity = -19.62f;
    public float groundDistance = 0.4f;
    public float pickuprange = 10f;
    public bool isGrounded;

    public void SaveGame()
    {
        SaveSystem.SavePlayer(this);
    }

    private void Start()
    {
        SaveGame();
    }

    void Update()
    {
        Cast = transform.GetComponentInChildren<CreateObject>();

        if (!Cast.Casting)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded) velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }

}
