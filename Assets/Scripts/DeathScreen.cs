using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    /// <summary>
    /// Menu scene name.
    /// </summary>
    public string menuSceneName;

    /// <summary>
    /// The time it takes to go back to the menu scene.
    /// </summary>
    public float waitTime;

    private void Start()
    {
        StartCoroutine(LoadToMenu());
    }

    IEnumerator LoadToMenu()
    {
        yield return new WaitForSeconds(waitTime);
        PlayerPrefs.SetInt("continue", 0);
        SceneManager.LoadScene(menuSceneName);
    }
}
