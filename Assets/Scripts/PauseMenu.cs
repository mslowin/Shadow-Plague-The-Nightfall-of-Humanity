using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// The Pause Menu object.
    /// </summary>
    public GameObject pauseMenu;

    /// <summary>
    /// Name of the main menu scene.
    /// </summary>
    public string sceneName;

    /// <summary>
    /// Determines whether game is paused or not.
    /// </summary>
    public bool toggle;

    public SC_FPSController playerScript;

    /// <summary>
    /// Happens all the time (in every frame).
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle = !toggle;
            if (!toggle)
            {
                pauseMenu.SetActive(false);
                AudioListener.pause = false;
                Time.timeScale = 1;
                playerScript.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

            if (toggle)
            {
                pauseMenu.SetActive(true);
                AudioListener.pause = true;
                Time.timeScale = 0;
                playerScript.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    /// <summary>
    /// When RESUME button is pressed.
    /// </summary>
    public void ResumeGame()
    {
        toggle = false;
        pauseMenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1;
        playerScript.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// When QUIT TO MENU button is pressed.
    /// </summary>
    public void QuitToMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// When QUIT TO DESKTOP button is pressed.
    /// </summary>
    public void QuitToDesktop()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        Debug.Log("The game will quit!");
        Application.Quit();
    }
}
