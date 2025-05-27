using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for allowing the player to pause the game
public class PlayerPauseGame : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    private InputManager inputManager;
    private PlayerHealth PlayerHealth;

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        PlayerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        //checks if player is alive and pause key triggered
        if (PlayerHealth.IsDead == false && inputManager.player.PauseGame.triggered)
        {
            menuManager.PauseGame();
        }
    }
}
