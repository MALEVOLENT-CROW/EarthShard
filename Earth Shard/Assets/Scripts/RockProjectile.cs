using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectile : MonoBehaviour
{

    //fields
    private Transform rockPos;
    [SerializeField] private Transform throwerPos;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private AudioClip[] impactSound;

    private MeshCollider rockCol;
    private Rigidbody rb;

    public bool held;

    [SerializeField] private float attackDamage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //gets position of thrower
        throwerPos = GameObject.FindWithTag("Thrower").GetComponent<Transform>();

        //gets components on obj
        rockPos = GetComponent<Transform>();
        rockCol = gameObject.GetComponent<MeshCollider>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        //checks if rock is held
        if(held)
        {
            HoldRock();
        }
        else { rockCol.enabled = true; rb.useGravity = true; }
    }

    //function disables gravity and collisions when rock is held
    private void HoldRock()
    {
        rockCol.enabled = false;
        rb.useGravity = false;
        rockPos.position = throwerPos.position;
        rockPos.rotation = throwerPos.rotation;
    }

    //destroys rock on collision and plays a sound and particle. damages enemy if the tag of the collision is an enemy.
    private void OnCollisionEnter(Collision collision)
    {
        if(!held)
        {
            GameObject hitGO = collision.gameObject;
            if(hitGO.CompareTag("Enemy"))
            {
                hitGO.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }

            AudioSource.PlayClipAtPoint(impactSound[Random.Range(0, impactSound.Length - 1)], transform.position);
            GameObject impactGO = Instantiate(impactEffect, transform.position, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            Destroy(impactGO, 2f);

            Destroy(gameObject);
        }
    }
}
