using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchaapTarget : MonoBehaviour
{
    public void Grow()
    {
        transform.localScale *= 1.1f;
    }

    public void Shrink()
    {
        transform.localScale *= .9f;
    }
}
