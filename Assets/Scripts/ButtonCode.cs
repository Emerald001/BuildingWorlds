using UnityEngine;

public class ButtonCode : CircuitPart 
{
    float standardPosition;
    private Collider Object;
    public GameObject movePiece;

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

            input = true;
        }
        else
        {
            movePiece.transform.position = new Vector3(transform.position.x, standardPosition, transform.position.z);

            input = false;
        }
    }
}
