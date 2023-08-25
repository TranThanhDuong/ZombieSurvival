using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Duy_Zombie_1_RunState : FSMState
{
    public Duy_Zombie_1_Control parent;
    public float timeDelay;

    public override void OnEnter()
    {
        if(parent.target==null)
        {
            parent.AutoRun();
        }
        
        parent.dataBinding.Speed = 1;

    }

    public override void OnFixedUpdate()
    {
        timeDelay -= Time.deltaTime;
        if (parent.target == null)
        {
            if (!parent.agent.hasPath)
            {

                parent.GotoState(parent.eatState);
                parent.GotoState(parent.startState);

            }

        }
        else
            parent.agent.SetDestination(parent.target.position);
       
    }
  

}
