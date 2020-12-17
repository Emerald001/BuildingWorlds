using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayGate : CircuitPart
{
    public GameObject Input;
    public float counter = 3;

    bool input1;

    private void Update()
    {
        input1 = Input.GetComponent<CircuitPart>().input;

        if (input1 && counter > 0)
        {
            input = false;

            counter -= Time.deltaTime;
        }
        else if(input1)
        {
            input = true;
        }
    }
}
