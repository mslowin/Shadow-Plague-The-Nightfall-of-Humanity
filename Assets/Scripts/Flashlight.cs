using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    /// <summary>
    /// The flashlight's light.
    /// </summary>
    public GameObject lightObject;

    /// <summary>
    /// Determines whether the flashlight is ON or not.
    /// </summary>
    public bool toggle;

    /// <summary>
    /// Sound of a flashlight turning ON and OFF.
    /// </summary>
    public AudioSource toggleSound;

    /// <summary>
    /// Happens before first render.
    /// </summary>
    private void Start()
    {
        if (!toggle)
        {
            lightObject.SetActive(false);
        }

        if (toggle)
        {
            lightObject.SetActive(true);
        }
    }

    /// <summary>
    /// Happens all the time (in every frame).
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            toggle = !toggle;
            //// toggleSound.Play();
            if (!toggle)
            {
                lightObject.SetActive(false);
            }

            if (toggle)
            {
                lightObject.SetActive(true);
            }
        }
    }
}
