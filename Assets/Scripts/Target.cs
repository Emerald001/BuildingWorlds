using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void Grow()
    {
        transform.localScale *= 2;
    }

    public void Shrink()
    {
        transform.localScale /= 2;
    }

}
