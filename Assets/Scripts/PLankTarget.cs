using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLankTarget : IsTarget
{
    Vector3 scaleChange = new Vector3(.07f, .003f, .02f);
    bool Grown;

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;

        transform.localScale = new Vector3(.01f, .01f, .01f);
    }

    void Update()
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

        if (transform.localScale.y < 0.2f && Grown)
        {
            Destroy(gameObject);
        }

        Die();
    }
}
