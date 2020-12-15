using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public float pickuprange;
    public float distance = 3f;
    public float smooth;
    public bool carrying;

    public Camera Cam;
    public GameObject TempParent;
    public GameObject CarriedObject;

    void Update()
    {
        if (carrying)
        {
            Carry(CarriedObject);
            CheckDrop();
        }
        else
        {
            PickUp();
        }
    }

    void Carry(GameObject Object)
    {
        Object.transform.position = Vector3.Lerp(Object.transform.position, TempParent.transform.position, Time.deltaTime * smooth);
        Object.transform.rotation = TempParent.transform.rotation;
    }

    void PickUp()
    {
        if (Input.GetKeyDown("e"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, pickuprange))
            {
                PickUpAble pickup = hit.transform.GetComponent<PickUpAble>();
                IsTarget target = hit.transform.GetComponent<IsTarget>();

                if (target.size < 4)
                {
                    if (pickup != null)
                    {
                        carrying = true;
                        CarriedObject = pickup.gameObject;
                        pickup.transform.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }
            }
        }
    }

    void CheckDrop()
    {
        if (Input.GetKeyDown("e"))
        {
            CarriedObject.transform.GetComponent<Rigidbody>().isKinematic = false;
            carrying = false;
            CarriedObject = null;
        }
    }
}
