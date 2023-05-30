using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMonster : MonoBehaviour
{
    /// <summary>
    /// Monster Game Object.
    /// </summary>
    public GameObject monster;

    /// <summary>
    /// The trigger collider to spawn the monster.
    /// </summary>
    public Collider collision;

    /// <summary>
    /// Happens upon entering a collider.
    /// </summary>
    /// <param name="other">The collider.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            monster.SetActive(true);
        }
        collision.enabled = false;
    }
}
