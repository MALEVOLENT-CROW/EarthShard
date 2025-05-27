using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//search state for enemy AI
//moves to players last seen position then moves around in a area looking for them before returning to patrol state
public class SearchState : BaseState
{
    private float searchTimer;
    private float moveTimer;
    public override void Enter()
    {
        enemy.Agent.SetDestination(enemy.LastKnowPos);
    }
    public override void Perform()
    {
        if(enemy.CanSeePlayer())
            stateMachine.ChangeState(new AttackState());

        if(enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;

            if(moveTimer > Random.Range(3, 5))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));
                moveTimer = 0;
            }

            if(searchTimer > 10)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public override void Exit()
    {

    }

}
