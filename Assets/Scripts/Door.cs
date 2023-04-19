using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class that contains logic connected with opening the door.
/// </summary>
public class Door : MonoBehaviour
{
    /// <summary>
    /// The interaction text.
    /// </summary>
    public GameObject intText;

    /// <summary>
    /// Determines if the door can be interacted with or not.
    /// </summary>
    public bool interactable;

    /// <summary>
    /// Determines if the door is opened or closed.
    /// </summary>
    public bool toggle;

    /// <summary>
    /// The door's animator.
    /// </summary>
    public Animator doorAnim;

    /// <summary>
    /// Happens when the player is looking at the door.
    /// </summary>
    /// <param name="other">Colider triggering the method.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }

    /// <summary>
    /// Happens when the player looks away from the door.
    /// </summary>
    /// <param name="other">Colider triggering the method.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }

    private void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                if (toggle)
                {
                    doorAnim.ResetTrigger("close");
                    doorAnim.SetTrigger("open");
                }

                if (!toggle)
                {
                    doorAnim.ResetTrigger("open");
                    doorAnim.SetTrigger("close");
                }

                intText.SetActive(false);
                interactable = false;
            }
        }
    }
}
