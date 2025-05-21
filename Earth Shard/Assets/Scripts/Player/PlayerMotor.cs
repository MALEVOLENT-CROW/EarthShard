using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5.0f;
    public float gravity = -9.8f;
    public float jumpHeight = 3.0f;

    private Transform playerTransform;

    [Header("footstep params")]
    [SerializeField] private float baseStepSpeed = 0.5f;
    [SerializeField] private AudioSource footstepAudioSource = default;
    [SerializeField] private AudioClip[] sandClips = default;
    [SerializeField] private AudioClip[] stoneClips = default;
    private float footstepTimer = 0;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        //plays foot steps
        HandleFootsteps();
    }

    //get inputs from InputManager.cs and apply them to character controller.
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2.0f;
        }
        controller.Move(playerVelocity * Time.deltaTime);

    }

    private void HandleFootsteps()
    {
        if(!controller.isGrounded) return;
        if(playerVelocity == Vector3.zero) return;

        footstepTimer -= Time.deltaTime;

        if(footstepTimer <= 0)
        {
            if(Physics.Raycast(playerTransform.position, Vector3.down, out RaycastHit hit, 3))
            {
                switch(hit.collider.tag)
                {
                }
            }
        }
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -jumpHeight * gravity);
        }
    }
}
