using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GroundRaise : MonoBehaviour
{
    //fields 
    public GameObject platformPrefab;
    private InputManager inputManager;
    private CharacterController controller;
    private Transform playerTransform;

    public float maxHeight = 5;
    public float speed = 2;
    public float slowFactor = 0.2f;

    private bool platformActive = false;
    private GameObject currentPlatform;
    private Vector3 platformStartPos;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GameObject.FindWithTag("Player").GetComponent<InputManager>();
        controller = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //spawns new platform on click
        if (inputManager.player.ShootAlt.triggered)
        {
            if (platformActive)
            {
                //destroys current platform
                Destroy(currentPlatform);
                platformActive = false;
            }
            else
            {
                //spawns new platform if player is grounded
                if (controller.isGrounded)
                {
                    SpawnPlatform();
                }
            }
        }

        //triggers platfrom to move up
        if (platformActive && inputManager.player.Shoot.ReadValue<float>() > 0)
        {           
            //move platform up and slow as it reaches max height
            if (currentPlatform.transform.position.y < platformStartPos.y + maxHeight)
            {
                float distanceToMaxHight = currentPlatform.transform.position.y - platformStartPos.y;
                if (distanceToMaxHight < maxHeight)
                {
                    //calc speed decrease based on distance
                    float speedMult = 1 - Mathf.Clamp01(distanceToMaxHight / maxHeight * slowFactor);

                    currentPlatform.transform.Translate(Vector3.up * speed * speedMult * Time.deltaTime);
                }        
            }
        }
    }

    private void SpawnPlatform()
    {
        //instantiate platform at players pos (adjust y value for player height)
        Vector3 spawnPosition = playerTransform.position + Vector3.down * 5f;
        currentPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        
        //face platform same direction as player
        currentPlatform.transform.rotation = Quaternion.Euler(0, playerTransform.rotation.eulerAngles.y, 0);

        //remember spawn pos for movement calc
        platformStartPos = currentPlatform.transform.position;

        platformActive = true;
    }
}
