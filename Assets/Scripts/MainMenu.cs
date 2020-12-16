using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject OptionsCanvas;
    public Vector3 position;
    public bool Continue;

    public LevelLoader Level;

    public void Options()
    {
        MenuCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);
    }

    public void NewGame()
    {
        Level.LoadNextLevel();
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        SceneManager.LoadScene(data.currentLevel);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
