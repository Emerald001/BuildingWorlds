using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public Slider slider; 
    private CreateObject value;

    private void OnTriggerEnter(Collider other)
    {
        slider.maxValue += 100;
        slider.value += 100;

        value = GameObject.Find("Player/MainCamera/BlockSpawn").GetComponent<CreateObject>();

        value.CurrentValue += 100;

        Destroy(gameObject);
    }
}
