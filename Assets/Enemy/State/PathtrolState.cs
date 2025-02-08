using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathtrolState : BaseState
{
    // Start is called before the first frame update
    public int waypointIndex;
    public float waitTimer;
    public override void Enter()
    {
     
    }
    public override void Perform()
    {
        PathtrolCycle();
        if(enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }
    public override void Exit()
    {
     
    }
    public void PathtrolCycle()
    {
        if(enemy.Agent.remainingDistance < 0.2f)
        {
            //int randomTimer = Random.Range( 5, 10);
            //Debug.Log(randomTimer);
            waitTimer += Time.deltaTime;
            if(waitTimer > 3)
            {
            if(waypointIndex < enemy.path.waypoints.Count -1)
            waypointIndex++;           
            else
                waypointIndex = 0;
                enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
                waitTimer = 0;  
            }
        }
    }
}
