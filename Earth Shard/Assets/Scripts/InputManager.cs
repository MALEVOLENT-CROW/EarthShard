using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //fields
    private PlayerInput playerInput;
    public PlayerInput.PlayerActions player;

    private PlayerMotor motor;
    private PlayerLook look;


    private void Awake()
    {
        playerInput = new PlayerInput();
        player = playerInput.Player;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        player.Jump.performed += ctx => motor.Jump();

        //lock cursor to cam
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //move player motor with movement action
        motor.ProcessMove(player.Move.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        look.ProcessLook(player.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        player.Enable();
    }

    private void OnDisable()
    {
        player.Disable();
    }
}
