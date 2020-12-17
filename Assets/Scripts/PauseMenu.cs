using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public Text CollectedText;
    public Animator Transition;
    public float transitionDuration = 1f;

    public float Collectables;
    public float MaxCollectables;

    void Update()
    {
        CollectedText.text = Collectables + " / " + MaxCollectables;

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("p"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        StartCoroutine(loadMenu());
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator loadMenu()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().SaveGame();

        Time.timeScale = 1f;

        yield return new WaitForSeconds(transitionDuration);

        SceneManager.LoadScene("main Menu");
    }
}
