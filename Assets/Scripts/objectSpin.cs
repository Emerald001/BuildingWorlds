using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpin : MonoBehaviour
{
    public Vector3 standardPosition;

    public float spinX;
    public float spinY;
    public float spinZ;
    public float movechange;

    private void Start()
    {
        standardPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinX, spinY, spinZ);

        if (transform.position.y > standardPosition.y + 1 || transform.position.y < standardPosition.y -1)
        {
            movechange *= -1;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + movechange, transform.position.z);
    }
}
