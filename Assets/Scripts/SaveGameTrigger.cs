using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameTrigger: MonoBehaviour
{
    public SC_FPSController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("continue", 1);
            SavingSystem.SaveGame(player);
        }
    }
}