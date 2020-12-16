using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int currentLevel;
    public float[] position;

    public PlayerData (PlayerMovement Player)
    {
        position = new float[3];

        position[0] = Player.transform.position.x;
        position[1] = Player.transform.position.y;
        position[2] = Player.transform.position.z;

        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }
}
