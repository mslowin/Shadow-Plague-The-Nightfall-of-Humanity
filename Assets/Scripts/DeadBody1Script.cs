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
    /// A wall to disapear when all bodies have been found.
    /// </summary>
    public GameObject wall;

    /// <summary>
    /// Determines whether or not the player is looking at the object.
    /// </summary>
    public bool interactable;

    /// <summary>
    /// Happens when the player looks at the object.
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
    /// Happens when the player looks away from the object.
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
                if(deadBody.name.Contains("1"))
                {
                    PlayerPrefs.SetInt("deadBody1Found", 1);
                    FindObjectOfType<AudioManager>().Play("Dial_DeadBody1");
                }  
                if(deadBody.name.Contains("2"))
                {
                    PlayerPrefs.SetInt("deadBody2Found", 1);
                    FindObjectOfType<AudioManager>().Play("Dial_DeadBody2");
                }  
                if(deadBody.name.Contains("3"))
                {
                    PlayerPrefs.SetInt("deadBody3Found", 1);
                    FindObjectOfType<AudioManager>().Play("Dial_DeadBody3");
                }  
            }
        }

        if (PlayerPrefs.GetInt("deadBody1Found") == 1 && PlayerPrefs.GetInt("deadBody2Found") == 1 && PlayerPrefs.GetInt("deadBody3Found") == 1)
        {
            wall.SetActive(false);
        }
    }
}
