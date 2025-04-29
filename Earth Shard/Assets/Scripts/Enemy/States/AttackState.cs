using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;

    public override void Enter()
    {

    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer()) //check if player can be seen
        {
            //lock losePlayerTimer and incriment move & shot Timers
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;

            Vector3 targetPos = new Vector3(enemy.Player.transform.position.x, enemy.transform.position.y, enemy.Player.transform.position.z);
            enemy.transform.LookAt(targetPos);//always look at player in this state

            if (shotTimer > enemy.fireRate)
            {
                Shoot();
            }

            //move to random pos after a random time
            if (moveTimer > Random.Range(4, 10))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.LastKnowPos = enemy.Player.transform.position;
        }
        else //player out of sight
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 10)
            {
                //change to search state
                stateMachine.ChangeState(new SearchState());
            }
        }
    }
    public override void Exit()
    {

    }
    public void Shoot()
    {
        //store ref to fire point
        Transform firePoint = enemy.firePoint;

        //instance new bullet
        GameObject Bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, firePoint.position, enemy.transform.rotation);

        //calculate dir to player
        Vector3 shootDirection = (enemy.Player.transform.position - firePoint.transform.position).normalized;

        //add force to rigidbody of bullet
        Bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f, 3f),Vector3.up) * shootDirection * enemy.bulletVelocity;

        Debug.Log("PewPew");
        shotTimer = 0;
    }
}
