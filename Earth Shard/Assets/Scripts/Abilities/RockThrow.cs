using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrow : MonoBehaviour
{
    private InputManager inputManager;

    [SerializeField] private GameObject projectileGO;
    private GameObject projectileInst;
    private RockProjectile projectileProperties;
    private Rigidbody projectileRB;
    private Animator animator;

    [SerializeField] private float projectileForce = 10.0f;
    [SerializeField] private float projectileUpForce = 1f;
   
    private bool spawned = false;

    private Transform rockThrower;


    // Start is called before the first frame update
    void Start()
    {
        inputManager = GameObject.FindWithTag("Player").GetComponent<InputManager>();

        rockThrower = GetComponent<Transform>();

        animator = GameObject.FindWithTag("Arms").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned == false && inputManager.player.ShootAlt.triggered)
        {
            spawnRock();
        }

        if (spawned == true && inputManager.player.Shoot.triggered)
        {
            shootRock();
        }
    }

    private void spawnRock()
    {
        if (projectileGO != null && rockThrower != null)
        {
            Vector3 spawnPos;

            spawnPos = rockThrower.position;

            GameObject projectile = Instantiate(projectileGO, spawnPos, Quaternion.identity);
            projectileRB = projectile.GetComponent<Rigidbody>();
            projectileProperties = projectile.GetComponent<RockProjectile>();
            projectileProperties.held = true;
            spawned = true;

        }
    }

    private void shootRock()
    {
        animator.Play("Shoot");

        projectileProperties.held = false;
        projectileRB.AddForce(transform.forward * projectileForce);
        projectileRB.AddForce(transform.up * projectileUpForce);

        spawned = false;
    }
}
