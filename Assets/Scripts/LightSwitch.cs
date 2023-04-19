using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains logic connected with switching on and off the light.
/// </summary>
public class LightSwitch : MonoBehaviour
{
    /// <summary>
    /// Interaction text object.
    /// </summary>
    public GameObject intText;

    /// <summary>
    /// Light object.
    /// </summary>
    public GameObject lightObject;

    /// <summary>
    /// Bool var that determines whether the light is on or not.
    /// </summary>
    public bool toggle;

    /// <summary>
    /// Bool that determines whether the light switch is being looked at by the player or not.
    /// </summary>
    public bool interactable;

    /// <summary>
    /// The light bulb's renderer.
    /// </summary>
    public Renderer lightBulb;

    /// <summary>
    /// Material of the light bulb when turned off.
    /// </summary>
    public Material offLightMaterial;

    /// <summary>
    /// Material of the light bulb when turned on.
    /// </summary>
    public Material onLightMaterial;

    /// <summary>
    /// Light switch audio source.
    /// </summary>
    public AudioSource lightSwitchSound;

    /// <summary>
    /// Light switch animator.
    /// </summary>
    public Animator switchAnim;

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
    /// Happens when the player is not looking at the switch.
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
    /// Happens all the time.
    /// </summary>
    private void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle; // switching the light on or off
                //// lightSwitchSound.Play();
                switchAnim.ResetTrigger("press");
                switchAnim.SetTrigger("press");
            }
        }

        if (!toggle) // when light switched off
        {
            lightObject.SetActive(false);
            lightBulb.material = offLightMaterial;
        }

        if (toggle) // when light switched on
        {
            lightObject.SetActive(true);
            lightBulb.material = onLightMaterial;
        }
    }
}
