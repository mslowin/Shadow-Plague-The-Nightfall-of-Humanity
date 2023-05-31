using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveGameTrigger: MonoBehaviour
{
    public SC_FPSController player;

    public GameObject monster;

    public TMP_Text batteriesNumberText;

    public Image batteryBar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("continue", 1);
            SavingSystem.SaveGame(player, monster, batteriesNumberText, batteryBar);
        }
    }
}
