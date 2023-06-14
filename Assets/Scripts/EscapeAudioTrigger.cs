using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeAudioTrigger : MonoBehaviour
{
    private bool entered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !entered)
        {
            FindObjectOfType<AudioManager>().Play("Dial_Escape");
            entered = true;
        }
    }
}
