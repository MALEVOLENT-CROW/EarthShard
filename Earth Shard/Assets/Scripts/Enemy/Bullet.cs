using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy projectile script controls damage enemy projectiles do
public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    private void OnCollisionEnter(Collision collision)
    {
        //checks if player is being collided with and damages player
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("hitPlayer");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
