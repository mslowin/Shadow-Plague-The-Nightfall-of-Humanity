using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    /// <summary>
    /// The loading screen.
    /// </summary>
    public GameObject loadingScreen;

    /// <summary>
    /// String of the first level's name.
    /// </summary>
    public string sceneName;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Called when PLAY button is pressed.
    /// </summary>
    public void PlayGame()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Called when QUIT button is pressed.
    /// </summary>
    public void QuitGame()
    {
        // as quiting doesn't work in editor we use debug log to check if it works.
        Debug.Log("Here the game should quit! (Only works in actual build, not in editor)");
        Application.Quit();
    }

    public void GitHubRepository()
    {
        Application.OpenURL("https://github.com/mslowin/Shadow-Plague-The-Nightfall-of-Humanity");
    }
}
