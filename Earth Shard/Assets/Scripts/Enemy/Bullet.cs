using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("hitPlayer");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
