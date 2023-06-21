using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ENDINGTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("continue", 0);
            PlayerPrefs.SetInt("deadBody1Found", 0);
            PlayerPrefs.SetInt("deadBody2Found", 0);
            PlayerPrefs.SetInt("deadBody3Found", 0);
            SceneManager.LoadScene("Credits");
        }
    }
}
