using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject PrefabCyl;
    public GameObject PrefabCub;
    public GameObject PrefabPlnk;
    public GameObject TempParent;
    public GameObject cantCast;
    public Slider slider;
    public float LowerBy = 0f;
    bool Casting;
    float ObjCounter;

    public Camera Cam;
    private float currentValue = 0f;

    private void Start()
    {
        CurrentValue = 1000f;
    }

    void Update()
    {
        Manalower();

        if (Input.GetKeyDown("1") && ObjCounter < 3 && currentValue > 100 && !Casting)
        {
            Instantiate(PrefabCub, Spawnpoint.position, Spawnpoint.rotation);

            ObjCounter += 1;
            LowerBy += 100f;
            StartCoroutine(Castin());    
        }
        else if (Input.GetKeyDown("1") && (ObjCounter == 3 || currentValue < 100))
        {
            StartCoroutine("CantCast");
        }

        if (Input.GetKeyDown("2") && ObjCounter < 3 && currentValue > 100 && !Casting)
        {
            Instantiate(PrefabCyl, Spawnpoint.position, Spawnpoint.rotation);

            ObjCounter += 1;
            LowerBy += 100f;
        }
        else if (Input.GetKeyDown("2") && (ObjCounter == 3 || currentValue < 100))
        {
            StartCoroutine(CantCast());
        }

        if (Input.GetKeyDown("3") && ObjCounter < 3 && currentValue > 100 && !Casting)
        {
            Instantiate(PrefabPlnk, Spawnpoint.position, Spawnpoint.rotation);

            ObjCounter += 1;
            LowerBy += 100f;
        }
        else if (Input.GetKeyDown("3") && (ObjCounter == 3 || currentValue < 100))
        {
            StartCoroutine(CantCast());
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GrowShoot();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            ShrinkShoot();
        }

        if (Input.GetKeyDown("q"))
        {
            RaycastHit kill;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out kill))
            {
                Target target = kill.transform.GetComponent<Target>();
                target.Kill = true;

                LowerBy -= 100f + target.pressed * 10f;

                ObjCounter -= 1;
            }
        }
    }

    void GrowShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null && CurrentValue > 10) LowerBy += 10;
            if (target != null && CurrentValue > 10) target.Grow();
        }
    }
    void ShrinkShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null) LowerBy -= 10;
            if (target != null) target.Shrink();
        }
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
        yield return new WaitForSeconds(3);
        Casting = false;
    }

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
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