using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTarget : MonoBehaviour
{
    Vector3 killChange = new Vector3(.1f, .1f, .1f);
    public bool Kill;
    public float size;

    public void Grow()
    {
        transform.localScale *= 1.1f;
        size += 1;
    }

    public void Shrink()
    {
        transform.localScale *= .9f;
        size -= 1;
    } 

    public void Die()
    {
        if (transform.localScale.y > 0.1f && Kill)
        {
            transform.localScale -= killChange;
        }

        if (transform.localScale.y < 0.2f && Kill)
        {
            Destroy(gameObject);
        }
    }
}
