using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public PauseMenu menu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("touched");

            menu.Collectables += 1;

            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }
}
