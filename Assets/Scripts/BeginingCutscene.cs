using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class containing logic for running the firsc cutscene.
/// </summary>
public class BeginingCutscene : MonoBehaviour
{
    /// <summary>
    /// The cutscene camera.
    /// </summary>
    public GameObject cutsceneCam;

    /// <summary>
    /// The player object.
    /// </summary>
    public GameObject player;

    /// <summary>
    /// Time the cutscene takes to run.
    /// </summary>
    public float cutsceneTime;

    /// <summary>
    /// Is cutscene playing?
    /// </summary>
    private bool cutscenePlaying = false;

    /// <summary>
    /// Coroutine for cutscene
    /// </summary>
    private Coroutine cutsceneCoroutine;

    /// <summary>
    /// Skip text
    /// </summary>
    public GameObject skipText;

    private void Start()
    {
        // when pressing continue we don't want the begining cutscene to play
        if (PlayerPrefs.GetInt("continue") == 1)
        {
            FindObjectOfType<AudioManager>().Play("Msc_Background");
            cutsceneCam.SetActive(false);
            player.SetActive(true);
        }

        // when pressing New Game we want the cutcene to play
        if (PlayerPrefs.GetInt("continue") == 0)
        {
            FindObjectOfType<AudioManager>().Play("Msc_Background");
            FindObjectOfType<AudioManager>().Play("Dial_Wstep");
            cutsceneCoroutine = StartCoroutine(cutscene());
        }
    }

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cutscenePlaying)
        {
            StopCutscene();
        }
    }

    IEnumerator cutscene()
    {
        cutscenePlaying = true;
        skipText.SetActive(true);
        yield return new WaitForSeconds(cutsceneTime);
        player.SetActive(true);
        cutsceneCam.SetActive(false);
        skipText.SetActive(false);
    }

    private void StopCutscene()
    {
        // Set cutscenePlaying to false when the cutscene is stopped
        cutscenePlaying = false;

        player.SetActive(true);
        cutsceneCam.SetActive(false);
        FindObjectOfType<AudioManager>().StopSound("Dial_Wstep");
        skipText.SetActive(false);

        if (cutsceneCoroutine != null)
        {
            StopCoroutine(cutsceneCoroutine);
        }
    }
}
