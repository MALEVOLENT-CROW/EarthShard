using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//subclass of targer for enemy health.
public class EnemyHealth : Target
{
    public override void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
