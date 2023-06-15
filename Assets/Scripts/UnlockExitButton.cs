using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockExitButton : MonoBehaviour
{

    /// <summary>
    /// Interaction text object.
    /// </summary>
    public GameObject intText;

    /// <summary>
    /// Bool that determines whether the switch is being looked at by the player or not.
    /// </summary>
    public bool interactable;

    /// <summary>
    /// Switch audio source.
    /// </summary>
    public AudioSource switchSound;

    /// <summary>
    /// Switch animator.
    /// </summary>
    public Animator switchAnim;

    /// <summary>
    /// Exit Door animator.
    /// </summary>
    public Animator exitDoor;

    private bool wasPressed = false;

    /// <summary>
    /// Happens when the player looks at the switch.
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
    /// Happens when the player looks away from the switch.
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

    /// <summary>
    /// Happens all the time (in every frame).
    /// </summary>
    private void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E) && !wasPressed)
            {
                //// switchSound.Play();
                switchAnim.ResetTrigger("press");
                switchAnim.SetTrigger("press");
                exitDoor.SetTrigger("open");
                wasPressed = true;
            }
        }
    }
}
