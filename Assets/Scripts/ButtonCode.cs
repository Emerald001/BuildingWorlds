using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCode : MonoBehaviour
{
    float GoDown = 0f;
    public GameObject movePiece;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GoDown += 10;
    }

    private void OnTriggerExit(Collider other)
    {
        GoDown -= 10;
    }

    private void Update()
    {
        if (GoDown > 0)
        {
            movePiece.transform.position = new Vector3(transform.position.x, movePiece.transform.position.y - .03f, transform.position.z);
            GoDown -= 1;
        }

        if (GoDown < 0)
        {
            movePiece.transform.position = new Vector3(transform.position.x, movePiece.transform.position.y + .03f, transform.position.z);
            GoDown += 1;
        }
    }
}
