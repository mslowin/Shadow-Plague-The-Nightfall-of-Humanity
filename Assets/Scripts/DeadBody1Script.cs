using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBody1Script : MonoBehaviour
{
    public GameObject deadBody;

    /// <summary>
    /// The interaction text.
    /// </summary>
    public GameObject intText;

    /// <summary>
    /// Determines whether or not the player is looking at the key card.
    /// </summary>
    public bool interactable;

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

    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //PlaySound     
            }
        }
    }
}
