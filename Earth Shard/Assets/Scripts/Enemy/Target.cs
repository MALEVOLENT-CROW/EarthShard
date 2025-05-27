using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//parent class for controlling enemy health
//orginally allowed for multiple classes too use a health system but only enemy has health now.
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
