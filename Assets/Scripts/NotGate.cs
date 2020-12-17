using UnityEngine;

public class NotGate : CircuitPart
{
    public GameObject Input;

    bool input1;

    private void Update()
    {
        input1 = Input.GetComponent<CircuitPart>().input;
        if (input1)
        {
            input = false;
        }
        else
        {
            input = true;
        }
    }
}
