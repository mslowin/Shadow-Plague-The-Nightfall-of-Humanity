using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        monster.SetActive(false); // if it wasn't false by mistake
        StartCoroutine(cutscene());
        StartCoroutine(door());
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
}
