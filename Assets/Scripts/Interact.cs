using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact : MonoBehaviour
{
    /// <summary>
    /// Bool to determine if the player is looking at the object and it can be interacted with.
    /// </summary>
    public bool interactable;

    /// <summary>
    /// Bool to determine if the object has been interacted with or not
    /// </summary>
    public bool toggle;

    /// <summary>
    /// Text that shows up when the object can be interacted with (e.g. "E").
    /// </summary>
    public GameObject intText;

    /// <summary>
    /// Text that shows up when the player interacts with the object.
    /// </summary>
    public GameObject dialogue;

    /// <summary>
    /// The string that will be a dialogue Text.
    /// </summary>
    public string dialogueString;

    /// <summary>
    /// The Text of the dialogue.
    /// </summary>
    public TMP_Text dialogueText;

    /// <summary>
    /// The amount of time the dialogue text will show up for.
    /// </summary>
    public float dialogueTime;

    /// <summary>
    /// Happens when the player looks at the object.
    /// </summary>
    /// <param name="other">Colider triggering the method.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (!toggle)
            {
                intText.SetActive(true);
                interactable = true;
            }
        }
    }

    /// <summary>
    /// Happens when the player looks away from the object.
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueText.text = dialogueString;
                dialogue.SetActive(true);
                intText.SetActive(false);
                StartCoroutine(DisableDialogue());
                toggle = true;
                interactable = false;
            }
        }
    }

    IEnumerator DisableDialogue()
    {
        yield return new WaitForSeconds(dialogueTime);
        dialogue.SetActive(false);
    }
}
