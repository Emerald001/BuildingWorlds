using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
    Vector3 plankChange = new Vector3(.07f, .003f, .02f);
    bool Grown;
    public bool Plank;
    public bool Kill;
    public float pressed;

    private void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;

        transform.localScale = new Vector3(.01f, .01f, .01f);
    }

    private void Update()
    {
        if (transform.localScale.y < 1f && !Grown && !Plank)
        {
            transform.localScale += scaleChange;
        }
        else if (!Plank)
        {
            Grown = true;

            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }

        if (transform.localScale.y < .3f && !Grown && Plank)
        {
            transform.localScale += plankChange;
        }
        else if(Plank)
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

        if (transform.localScale.y < 0.2f && Grown)
        {
            Destroy(gameObject);
        }
    }

    public void Grow()
    {
        transform.localScale *= 1.1f;

        pressed += 1;
    }

    public void Shrink()
    {
        transform.localScale *= .9f;

        pressed -= 1;
    } 
}
