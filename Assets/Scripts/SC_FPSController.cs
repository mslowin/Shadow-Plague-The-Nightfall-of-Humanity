﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    /// <summary>
    /// Flashlight the player is holding.
    /// </summary>
    public GameObject flashLight_Hand;

    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    private bool isStanding = true;

    private bool wasRunning = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (PlayerPrefs.GetInt("continue") == 1)
        {
            SaveData data = SavingSystem.LoadData();

            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;
            flashLight_Hand.SetActive(true);
        }
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        bool isMoving = Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;

        if (isMoving && isStanding)
        {
            // Player started moving, play walking sound
            FindObjectOfType<AudioManager>().PlayNotInteruptable("FX_Walking");
            isStanding = false;
            wasRunning = false;
        }
        else if (!isMoving && !isStanding)
        {
            // Player stopped moving, stop walking sound
            FindObjectOfType<AudioManager>().StopSound("FX_Walking");
            isStanding = true;
            wasRunning = false;
        }

        if (isMoving && isRunning && FindObjectOfType<AudioManager>().isPlayingSound("FX_Running") == false)
        {
            // Player started running, play running sound
            FindObjectOfType<AudioManager>().StopSound("FX_Walking");
            FindObjectOfType<AudioManager>().PlayNotInteruptable("FX_Running");
            wasRunning = true;
        }
        else if ((!isMoving || !isRunning) && FindObjectOfType<AudioManager>().isPlayingSound("FX_Running") == true)
        {
            // Player stopped running, stop running sound
            FindObjectOfType<AudioManager>().StopSound("FX_Running");
            wasRunning = false;
        }
        else if (isMoving && wasRunning)
        {
            FindObjectOfType<AudioManager>().PlayNotInteruptable("FX_Walking");
        }

        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}