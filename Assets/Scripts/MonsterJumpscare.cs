using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterJumpscare : MonoBehaviour
{
    /// <summary>
    /// Monster's animator.
    /// </summary>
    public Animator monsterAnimator;

    /// <summary>
    /// The player.
    /// </summary>
    public GameObject player;

    /// <summary>
    /// The time it takes for the jumpscare to finish and go to the death scene.
    /// </summary>
    public float jumpscareTime;

    /// <summary>
    /// Death scene's name
    /// </summary>
    public string deathSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.SetActive(false);
            monsterAnimator.SetTrigger("Jumpscare");
            StartCoroutine(Jumpscare());
        }
    }

    IEnumerator Jumpscare()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(deathSceneName);
    }
}
