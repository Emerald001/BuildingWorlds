using System.Collections;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject PrefabCyl;
    public GameObject PrefabCub;
    public GameObject TempParent;

    public Camera Cam;
    public float range = 100f;
    bool grabbed;


    // Start is called before the first frame update
    void Update() {
        if (Input.GetKeyDown("1"))
        {
            Instantiate(PrefabCub, Spawnpoint.position, Spawnpoint.rotation);
        }

        if (Input.GetKeyDown("2")) {
            Instantiate(PrefabCyl, Spawnpoint.position, Spawnpoint.rotation);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GrowShoot();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            ShrinkShoot();
        }

        if (Input.GetKeyDown("e"))
        {

            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
            {
                hit.transform.GetComponent<Rigidbody>().useGravity = false;
                hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.position = Spawnpoint.transform.position;
                hit.transform.rotation = Spawnpoint.transform.rotation;
                hit.transform.parent = TempParent.transform;

                grabbed = true;
            }
        }

        if (Input.GetKeyUp("e"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
            {
                hit.transform.GetComponent<Rigidbody>().useGravity = true;
                hit.transform.GetComponent<Rigidbody>().isKinematic = false;
                hit.transform.position = Spawnpoint.transform.position;
                hit.transform.parent = null;

                grabbed = false;
            }
        }
    }

    void GrowShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null) target.Grow();
        }

    }
    void ShrinkShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null) target.Shrink();
        }

    }

    void Grab()
    {

    }

    void LetGo()
    {

    }
}
