using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;

    public void Initialise()
    {      
        //default state
        ChangeState(new PatrolState());
    }

    // Update is called once per frame
    void Update()
    {
        activeState.Perform();
    }
    public void ChangeState(BaseState newState)
    {
        //check activeState != null
        if (activeState != null)
        {
            //run cleanup on activeState
            activeState.Exit();
        }
        //change to a new state
        activeState = newState;

        //failsafe null check to make sure new state wasnt null
        if (activeState != null)
        {
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
