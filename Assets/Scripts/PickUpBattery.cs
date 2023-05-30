using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpBattery : MonoBehaviour
{
    public TMP_Text batteriesNumberText;

    /// <summary>
    /// The interaction text.
    /// </summary>
    public GameObject intText;

    /// <summary>
    /// Battery lying on the table.
    /// </summary>
    public GameObject battery;

    /// <summary>
    /// Determines whether or not the player is looking at the battery
    /// </summary>
    public bool interactable;

    /// <summary>
    /// Happens when the player looks at the battery.
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
    /// Happens when the player looks away from the battery.
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
                int batteriesnum = int.Parse(batteriesNumberText.text);
                batteriesnum += 1;
                batteriesNumberText.text = batteriesnum.ToString();
                intText.SetActive(false);
                interactable = false;
                battery.SetActive(false);
            }
        }
    }
}
