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
    /// The Options Menu object.
    /// </summary>
    public GameObject optionsMenu;

    public GameObject note1;
    public GameObject note2;
    public GameObject note3;
    public GameObject note4;
    private bool note1Active = false;
    private bool note2Active = false;
    private bool note3Active = false;
    private bool note4Active = false;
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
                if (note1.activeSelf == false && note1Active)
                {
                    note1.SetActive(true);
                    note1Active = false;
                } else if (note2.activeSelf == false && note2Active)
                {
                    note2.SetActive(true);
                    note2Active = false;
                } else if (note3.activeSelf == false && note3Active)
                {
                    note3.SetActive(true);
                    note3Active = false;
                } else if (note4.activeSelf == false && note4Active)
                {
                    note4.SetActive(true);
                    note4Active = false;
                }
            }

            if (toggle)
            {
                pauseMenu.SetActive(true);
                AudioListener.pause = true;
                Time.timeScale = 0;
                playerScript.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                if (note1.activeSelf)
                {
                    note1.SetActive(false);
                    note1Active = true;
                } else if (note2.activeSelf)
                {
                    note2.SetActive(false);
                    note2Active = true;
                } else if (note3.activeSelf)
                {
                    note3.SetActive(false);
                    note3Active = true;
                } else if (note4.activeSelf)
                {
                    note4.SetActive(false);
                    note4Active = true;
                }
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
    /// When SETTINGS button is pressed.
    /// </summary>
    public void Settings()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
