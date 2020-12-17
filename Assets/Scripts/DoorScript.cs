using UnityEngine;

public class DoorScript : Movable
{
    public GameObject Input;

    private float standardPosition;
    public float movementSpeed = 2f;

    void Start()
    {
        standardPosition = transform.position.y;
    }

    void Update()
    {
        if (Input.GetComponent<CircuitPart>().input)
        {
            if (transform.position.y > standardPosition - transform.localScale.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - movementSpeed * Time.deltaTime, transform.position.z);
            }
        }
        else
        {
            if (transform.position.y < standardPosition)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + movementSpeed * Time.deltaTime, transform.position.z);
            }
        }
    }
}
