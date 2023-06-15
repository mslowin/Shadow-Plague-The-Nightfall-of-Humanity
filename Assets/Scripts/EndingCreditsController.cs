using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCreditsController : MonoBehaviour
{
    public int secondsOfCreditsRolling;

    private void Start()
    {
        StartCoroutine(cutscene());
    }

    IEnumerator cutscene()
    {
        yield return new WaitForSeconds(secondsOfCreditsRolling);
        SceneManager.LoadScene("Menu");
        PlayerPrefs.SetInt("continue", 0);
    }
}
