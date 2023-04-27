using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for managing players camera animations.
/// </summary>
public class CamBob : MonoBehaviour
{
    /// <summary>
    /// The player cam's animator.
    /// </summary>
    public Animator cameraAnim;

    /// <summary>
    /// Bool to determine if the player is walking.
    /// </summary>
    public bool walking;

    /// <summary>
    /// Happens every frame.
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            walking = true;
            cameraAnim.ResetTrigger("idle");
            cameraAnim.ResetTrigger("sprint");
            cameraAnim.SetTrigger("walk");
            if (walking == true)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    cameraAnim.ResetTrigger("walk");
                    cameraAnim.ResetTrigger("idle");
                    cameraAnim.SetTrigger("sprint");
                }
            }
        }
        else
        {
            cameraAnim.ResetTrigger("walk");
            cameraAnim.ResetTrigger("sprint");
            cameraAnim.SetTrigger("idle");
            walking = false;
        }
    }
}

