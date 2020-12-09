using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCode : MonoBehaviour
{
    float standardPosition;
    Collider Object;
    public bool onButton;
    public GameObject movePiece;

    public GameObject movable;

    private void Start()
    {
        standardPosition = movePiece.transform.position.y;
        Object = null;
    }

    private void OnTriggerStay(Collider other)
    {
        Object = other;
    }

    private void OnTriggerExit(Collider other)
    {
        Object = null;
    }

    private void Update()
    {
        ButtonDown(Object);
    }

    void ButtonDown(Collider hit)
    {
        if (hit != null)
        {
            movePiece.transform.position = new Vector3(transform.position.x, standardPosition - .2f, transform.position.z);

            movable.transform.GetComponent<Movable>().moving = true;
        }
        else
        {
            movePiece.transform.position = new Vector3(transform.position.x, standardPosition, transform.position.z);

            movable.transform.GetComponent<Movable>().moving = false;
        }
    }
}
