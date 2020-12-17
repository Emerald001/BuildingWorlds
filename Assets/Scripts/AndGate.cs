using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndGate : CircuitPart
{
    public GameObject Input1;
    public GameObject Input2;

    bool input1;
    bool input2;

    private void Update()
    {
        input1 = Input1.GetComponent<CircuitPart>().input;
        input2 = Input2.GetComponent<CircuitPart>().input;

        if (input1 && input2)
        {
            input = true;
        }
        else
        {
            input = false;
        }
    }
}
