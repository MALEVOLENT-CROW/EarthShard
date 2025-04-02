using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Target
{
    private Enemy enemy;

    private void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
    }

    public override void TakeDamage(float amount)
    {
        health -= amount;
        //look at player when attacked
        enemy.transform.LookAt(enemy.Player.transform);
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
