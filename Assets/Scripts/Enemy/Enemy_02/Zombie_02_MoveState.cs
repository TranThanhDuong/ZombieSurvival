using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Zombie_02_MoveState : FSMState
{
    public Zombie_02_Control parent;
    private float timeDelay;
    public override void OnEnter()
    {
        if(parent.target==null)
            parent.Walk();
        parent.dataBinding.Key_SpeedMove = 1;
        timeDelay = UnityEngine.Random.Range(2, 4);
    }

    public override void OnUpdate()
    {
        if(parent.target==null)
        {
            if(!parent.agent.hasPath)
            {
                parent.GotoState(parent.idleState);
            }
        }
        else
        {
            parent.agent.SetDestination(parent.target.position);
            
        }
    }
}