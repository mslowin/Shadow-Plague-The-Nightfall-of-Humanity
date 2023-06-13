using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class with logic to pick up the key card.
/// </summary>
public class PickUpKeyCard : MonoBehaviour
{
    /// <summary>
    /// The interaction text.
    /// </summary>
    public GameObject intText;

    /// <summary>
    /// KeyCard lying on the table.
    /// </summary>
    public GameObject keyCard;

    /// <summary>
    /// The pickup sound.
    /// </summary>
    public AudioSource pickupSound;
    
    /// <summary>
    /// Determines whether or not the player is looking at the key card.
    /// </summary>
    public bool interactable;

    /// <summary>
    /// Determines whether a scarry should happen after picking up the key.
    /// </summary>
    public bool scarryEvent;

    /// <summary>
    /// Game object containing the blood stains.
    /// </summary>
    public GameObject bloodStains;

    /// <summary>
    /// Happens when the player looks at the key card.
    /// </summary>
    /// <param name="other">Colider triggering the method.</param>
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }

    /// <summary>
    /// Happens when the player looks away from the key card.
    /// </summary>
    /// <param name="other">Colider triggering the method.</param>
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }

    /// <summary>
    /// Happens all the time (in every frame).
    /// </summary>
    private void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                intText.SetActive(false);
                interactable = false;
                FindObjectOfType<AudioManager>().Play("Dial_CardFound");
                if (scarryEvent)
                {
                    bloodStains.SetActive(true);
                }
                keyCard.SetActive(false);
            }
        }
    }
}
