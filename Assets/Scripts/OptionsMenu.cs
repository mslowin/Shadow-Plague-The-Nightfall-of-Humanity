using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    /// <summary>
    /// The Pause Menu object.
    /// </summary>
    public GameObject pauseMenu;

    /// <summary>
    /// The Options Menu object.
    /// </summary>
    public GameObject optionsMenu;

    public Slider sliderMusic;
    
    public Slider sliderFX;

    public Slider sliderDialogue;

    private string type;

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<AudioManager>().ChangeVolume(sliderMusic.value, type);

        FindObjectOfType<AudioManager>().ChangeVolume(sliderFX.value, type);

        FindObjectOfType<AudioManager>().ChangeVolume(sliderDialogue.value, type);
    }

    /// <summary>
    /// When RETURN button is pressed.
    /// </summary>
    public void Return()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
