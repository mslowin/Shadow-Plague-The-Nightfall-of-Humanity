using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class with logic to pick up the flashlight.
/// </summary>
public class PickUpFlashLight : MonoBehaviour
{
    /// <summary>
    /// The interaction text.
    /// </summary>
    public GameObject intText;

    /// <summary>
    /// Flashlight lying on the table.
    /// </summary>
    public GameObject flashLight_Table;
    
    /// <summary>
    /// Flashlight the player is holding.
    /// </summary>
    public GameObject flashLight_Hand;

    /// <summary>
    /// The pickup sound.
    /// </summary>
    public AudioSource pickupSound;
    
    /// <summary>
    /// Determines whether or not the player is looking at the flashlight
    /// </summary>
    public bool interactable;

    /// <summary>
    /// Happens when the player looks at the flashlight.
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
    /// Happens when the player looks away from the flashlight.
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
                //// pickupSound.Play();
                flashLight_Hand.SetActive(true);
                flashLight_Table.SetActive(false);
            }
        }
    }
}
