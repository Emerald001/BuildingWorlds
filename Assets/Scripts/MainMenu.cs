using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject OptionsCanvas;

    public LevelLoader Level;

    public void Options()
    {
        MenuCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);
    }

    public void Play()
    {
        Level.LoadNextLevel();
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
