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

    private void Start()
    {
        // when pressing continue we don't want the begining cutscene to play
        if (PlayerPrefs.GetInt("continue") == 1)
        {
            cutsceneCam.SetActive(false);
            player.SetActive(true);
        }

        // when pressing New Game we want the cutcene to play
        if (PlayerPrefs.GetInt("continue") == 0)
        {
            StartCoroutine(cutscene());
        }
    }

    IEnumerator cutscene()
    {
        yield return new WaitForSeconds(cutsceneTime);
        player.SetActive(true);
        cutsceneCam.SetActive(false);
    }
}
