using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer;
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
                Debug.Log("Work");
                searchTimer += Time.deltaTime;
                if(searchTimer > 10)
                {
                    stateMachine.ChangeState(new PathtrolState());
                }
            }
    }
    public override void Exit()
    {
        
    }
}
