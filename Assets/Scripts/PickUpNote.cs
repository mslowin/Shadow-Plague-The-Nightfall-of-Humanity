using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpNote : MonoBehaviour
{
    /// <summary>
    /// KeyCard lying on the table.
    /// </summary>
    public CamBob camera;

    /// <summary>
    /// KeyCard lying on the table.
    /// </summary>
    public SC_FPSController player;

    /// <summary>
    /// KeyCard lying on the table.
    /// </summary>
    public GameObject note;

    /// <summary>
    /// The interaction text.
    /// </summary>
    public GameObject intText;

    /// <summary>
    /// Determines whether or not the player is looking at the key card.
    /// </summary>
    public bool interactable;

    public bool toggle = false;

    // Start is called before the first frame update
    void Start()
    {
        note.SetActive(false);
    }

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
                toggle = !toggle;
                if (!toggle)
                {
                    note.SetActive(true);
                    player.enabled = false;
                    camera.enabled = false;
                }

                if (toggle)
                {
                    note.SetActive(false);
                    player.enabled = true;
                    camera.enabled = true;
                }           
            }
        }
    }
}
