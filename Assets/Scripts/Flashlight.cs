using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    /// The trigger that can be disabled when the light is.
    /// </summary>
    public GameObject slowDownTrigger;

    /// <summary>
    /// Sound of a flashlight turning ON and OFF.
    /// </summary>
    public AudioSource toggleSound;

    /// <summary>
    /// Battery bar image.
    /// </summary>
    public Image barImage;

    /// <summary>
    /// Battery bar fill.
    /// </summary>
    public double barFillAmount = 1;

    /// <summary>
    /// Speed of Battery bar decrease.
    /// </summary>
    public float barDecrease = 10f;

    /// <summary>
    /// Number of batteries.
    /// </summary>
    public TMP_Text batteriesNumberText;


    /// <summary>
    /// Happens before first render.
    /// </summary>
    private void Start()
    {
        if (PlayerPrefs.GetInt("continue") == 1)
        {
            SaveData data = SavingSystem.LoadData();
            batteriesNumberText.text = data.batteriesNumber.ToString();
            barImage.fillAmount = data.batteryBarFillAmount;
        }

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
        int batteriesnum = int.Parse(batteriesNumberText.text);

        if (barImage.fillAmount > 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                toggle = !toggle;
                //// toggleSound.Play();
                if (!toggle)
                {
                    lightObject.SetActive(false);
                    slowDownTrigger.SetActive(false);
                }

                if (toggle)
                {
                    lightObject.SetActive(true);
                    slowDownTrigger.SetActive(true);
                }
            }
        }
        else
        {
            lightObject.SetActive(false);
        }

        // Bar dropping down over time
        if (toggle && barImage.fillAmount > 0)
        {
            barImage.fillAmount -= barDecrease * Time.deltaTime;
            barImage.fillAmount = Mathf.Clamp01(barImage.fillAmount);
        }

        // Reloading batteries
        if (Input.GetKeyDown(KeyCode.R) && batteriesnum > 0)
        {
            barImage.fillAmount = 1;
            batteriesnum -= 1;
            batteriesNumberText.text = batteriesnum.ToString();
        }
    }
}
