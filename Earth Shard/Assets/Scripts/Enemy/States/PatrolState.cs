using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    //track which waypoint we are targeting currently
    public int waypointIndex;
    public float waitTimer;
    public override void Enter()
    {

    }
    public override void Perform()
    {
        //disabled for testing
        PatrolCycle();
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }
    public override void Exit()
    {

    }

    public void PatrolCycle()
    {
        //patrol logic
        if (enemy.Agent.remainingDistance < 0.2f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > 3) //edit wait time here
            {
                if (waypointIndex < enemy.path.waypoints.Count - 1)
                    waypointIndex++;
                else
                    waypointIndex = 0;
                enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
                waitTimer = 0;
            }
        }
    }
}
