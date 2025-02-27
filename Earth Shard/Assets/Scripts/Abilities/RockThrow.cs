using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrow : MonoBehaviour
{
    private InputManager inputManager;

    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject rockThrower;
    [SerializeField] private float projectileForce = 10.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void spawnRock()
    {
        if(projectile != null && rockThrower != null)
        {
            Vector3 spawnPos;

           // Instantiate(projectile,rockThrower,Quaternion.identity) ;
        }
    }

    private void shootRock()
    {

    }
}
