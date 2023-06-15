using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBigDoorTrigger : MonoBehaviour
{
    /// <summary>
    /// The big door animator.
    /// </summary>
    public Animator bigDoorAnim;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bigDoorAnim.SetTrigger("open");
        }
    }
}
