using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
    bool Grown;
    public bool Kill;

    private void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;

        transform.localScale = new Vector3(.01f, .01f, .01f);
    }

    private void Update()
    {
        if (transform.localScale.y < 1f && !Grown)
        {
            transform.localScale += scaleChange;
        }
        else
        {
            Grown = true;

            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }

        if (transform.localScale.y > 0.1f && Kill)
        {
            transform.localScale -= scaleChange;
        }

        if (transform.localScale.y < 0.2f && Kill)
        {
            Destroy(gameObject);
        }
    }

    public void Grow()
    {
        transform.localScale *= 1.1f;
    }

    public void Shrink()
    {
        transform.localScale *= .9f;
    } 
}
