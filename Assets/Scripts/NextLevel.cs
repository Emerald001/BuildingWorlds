using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public LevelLoader Level;

    private void OnTriggerEnter(Collider other)
    {
        Level.LoadNextLevel();
    }
}
