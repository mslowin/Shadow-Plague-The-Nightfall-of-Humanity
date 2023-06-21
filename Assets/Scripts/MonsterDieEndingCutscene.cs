using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterDieEndingCutscene : MonoBehaviour
{
    /// <summary>
    /// The monster object.
    /// </summary>
    public GameObject monster;

    /// <summary>
    /// Door animator.
    /// </summary>
    public Animator doorAnimator;

    /// <summary>
    /// Time when the monster should appear.
    /// </summary>
    public float timeToMonsterAppear;

    /// <summary>
    /// Time when the door should open.
    /// </summary>
    public float timeToDoorOpen;

    /// <summary>
    /// Time when the credits scene should be loaded.
    /// </summary>
    public float timeToCredits;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Dial_Ending");
        monster.SetActive(false); // if it wasn't false by mistake
        StartCoroutine(cutscene());
        StartCoroutine(door());
        StartCoroutine(credits());
    }

    IEnumerator cutscene()
    {
        yield return new WaitForSeconds(timeToMonsterAppear);
        monster.SetActive(true);
    }

    IEnumerator door()
    {
        yield return new WaitForSeconds(timeToDoorOpen);
        doorAnimator.SetTrigger("open");
    }

    IEnumerator credits()
    {
        yield return new WaitForSeconds(timeToCredits);
        PlayerPrefs.SetInt("continue", 0);
        PlayerPrefs.SetInt("deadBody1Found", 0);
        PlayerPrefs.SetInt("deadBody2Found", 0);
        PlayerPrefs.SetInt("deadBody3Found", 0);
        SceneManager.LoadScene("Credits");
    }
}
