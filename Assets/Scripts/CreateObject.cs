using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject PrefabCub;
    public GameObject cantCast;
    public Slider slider;
    public Animator Left;
    public Animator Right;
    public float LowerBy = 0f;
    public bool Casting;
    float ObjCounter;
    public int layerMask = 1 << 10;

    public Camera Cam;
    private float currentValue = 0f;
    private PlayerMovement player;
    private PickUpObject pickUp;

    private void Start()
    {
        CurrentValue = slider.value;
    }

    void Update()
    {
        layerMask = ~layerMask;

        player = transform.GetComponentInParent<PlayerMovement>();
        pickUp = transform.GetComponent<PickUpObject>();

        Manalower();

        if (!pickUp.carrying)
        {
            if (Input.GetMouseButtonDown(2)) Cast(PrefabCub);

            if (Input.GetKeyDown("q"))
            {
                RaycastHit kill;
                if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out kill, Mathf.Infinity, layerMask))
                {
                    IsTarget target = kill.transform.GetComponent<IsTarget>();
                    target.Kill = true;

                    LowerBy -= 100f + target.size * 10f;

                    ObjCounter -= 1;

                    Left.SetTrigger("Delete");
                    Right.SetTrigger("Delete");
                }
            }
        }
    }

    void Cast(GameObject input)
    {
        if (ObjCounter < 3 && currentValue > 100 && !Casting && player.isGrounded) {
            Instantiate(input, Spawnpoint.position, Spawnpoint.rotation);

            ObjCounter += 1;
            LowerBy += 100f;
            StartCoroutine(Castin());
        }
        else if (ObjCounter == 3 || currentValue < 100) {
            StartCoroutine("CantCast");
        }
        input = null;
    }

    IEnumerator CantCast()
    {
        cantCast.SetActive(true);
        yield return new WaitForSeconds(3);
        cantCast.SetActive(false);
    }

    IEnumerator Castin()
    {
        Casting = true;

        Left.SetTrigger("Activate");
        Right.SetTrigger("Activate");

        yield return new WaitForSeconds(1.2f);

        Casting = false;
    }

    public float CurrentValue
    {
        get { return currentValue; }
        set {
            currentValue = value;
            slider.value = currentValue;
        }
    }

    void Manalower()
    {
        if (LowerBy > 0)
        {
            CurrentValue -= 1;
            LowerBy -= 1;
        }

        if (LowerBy < 0)
        {
            CurrentValue += 1;
            LowerBy += 1;
        }
    }
}