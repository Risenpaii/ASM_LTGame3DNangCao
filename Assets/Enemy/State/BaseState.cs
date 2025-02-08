using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    // Start is called before the first frame update
    public StateMachine stateMachine;
    public Enemy enemy;
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();

}
