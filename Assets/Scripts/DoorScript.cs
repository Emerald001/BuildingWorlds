using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Movable
{
    public float standardPosition;

    void Start()
    {
        standardPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (transform.position.y > standardPosition - transform.localScale.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 2f * Time.deltaTime, transform.position.z);
            }
        }
        else
        {
            if (transform.position.y < standardPosition)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 2f * Time.deltaTime, transform.position.z);
            }
        }
    }
}
