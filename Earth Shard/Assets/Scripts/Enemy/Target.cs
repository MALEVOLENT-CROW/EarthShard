using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50.0f; //health of obj

    //obj take damage logic
    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        //to be overridden
        Destroy(gameObject);
    }
}
