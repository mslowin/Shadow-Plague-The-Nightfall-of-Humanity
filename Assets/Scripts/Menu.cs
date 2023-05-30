using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    /// <summary>
    /// The CONTINUE button.
    /// </summary>
    public Button continueButton;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("continue") == 0)
        {
            continueButton.interactable = false;
        }
    }

    public void continueGame()
    {
        loadingScreen.SetActive(true);

        PlayerPrefs.SetInt("continue", 1);

        SceneManager.LoadScene(sceneName);

    }

    /// <summary>
    /// Called when NEW GAME button is pressed.
    /// </summary>
    public void PlayGame()
    {
        loadingScreen.SetActive(true);
        // PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("continue", 0);
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
