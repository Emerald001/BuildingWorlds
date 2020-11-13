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
    public GameObject Casting;
    public Slider slider;
    float ObjCounter;

    public Camera Cam;
    private float currentValue = 0f;

    private void Start()
    {
        CurrentValue = 1000f;
    }

    void Update() {

        if (Input.GetKeyDown("1") && ObjCounter < 3 && currentValue > 100) {
            Instantiate(PrefabCub, Spawnpoint.position, Spawnpoint.rotation);

            ObjCounter += 1;
            CurrentValue -= 100f;
        }
        else if (Input.GetKeyDown("1") && (ObjCounter == 3 || currentValue < 100)) {
            StartCoroutine("CantCast");
        }

        if (Input.GetKeyDown("2") && ObjCounter < 3 && currentValue > 100) {
            Instantiate(PrefabCyl, Spawnpoint.position, Spawnpoint.rotation);

            ObjCounter += 1;
            CurrentValue -= 100f;
        }
        else if (Input.GetKeyDown("2") && (ObjCounter == 3 || currentValue < 100)) {
            StartCoroutine(CantCast());
        }

        if (Input.GetKeyDown("3") && ObjCounter < 3 && currentValue > 100)
        {
            Instantiate(PrefabPlnk, Spawnpoint.position, Spawnpoint.rotation);

            ObjCounter += 1;
            CurrentValue -= 100f;
        }
        else if (Input.GetKeyDown("3") && (ObjCounter == 3 || currentValue < 100))
        {
            StartCoroutine(CantCast());
        }

        if (Input.GetButtonDown("Fire1")) {
            GrowShoot();
        }

        if (Input.GetButtonDown("Fire2")) {
            ShrinkShoot();
        }

        if (Input.GetKeyDown("q")) {
            RaycastHit kill;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out kill)) {
                Target target = kill.transform.GetComponent<Target>();
                target.Kill = true;

                CurrentValue += 100f + target.pressed * 10f;

                ObjCounter -= 1;
            }
        }

        if (Input.GetKeyDown("e")) {
            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit)) {
                hit.transform.GetComponent<Rigidbody>().useGravity = false;
                hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.position = Spawnpoint.transform.position;
                hit.transform.rotation = Spawnpoint.transform.rotation;
                hit.transform.parent = TempParent.transform;
            }
        }

        if (Input.GetKeyUp("e")) {
            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit)) {
                hit.transform.GetComponent<Rigidbody>().useGravity = true;
                hit.transform.GetComponent<Rigidbody>().isKinematic = false;
                hit.transform.position = Spawnpoint.transform.position;
                hit.transform.parent = null;
            }
        }
    }

    void GrowShoot() {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit)) {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null && CurrentValue > 10) CurrentValue -= 10;
            if (target != null && CurrentValue > 10) target.Grow();
        }
    }
    void ShrinkShoot() {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit)) {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null) CurrentValue += 10;
            if (target != null) target.Shrink();
        }
    }

    IEnumerator CantCast() {
        Casting.SetActive(true);
        yield return new WaitForSeconds(3);
        Casting.SetActive(false);
    }

    public float CurrentValue {
        get {
            return currentValue;
        }
        set {
            currentValue = value;
            slider.value = currentValue;
        }
    }
}
