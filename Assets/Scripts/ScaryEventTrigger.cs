using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryEventTrigger : MonoBehaviour
{
    /// <summary>
    /// The object that will do the scare.
    /// </summary>
    public GameObject scarryObject;

    /// <summary>
    /// The trigger's collider.
    /// </summary>
    public Collider collision;

    /// <summary>
    /// Jumpscare sound.
    /// </summary>
    public AudioSource scareSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scarryObject.SetActive(true);
            //// scareSound.Play();
            collision.enabled = false;
        }
    }
}
