using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Enemy_01_WalkState : FSMState
{
    [NonSerialized]
    public Enemy_01_Control parent;
    public override void OnEnter()
    {
        parent.dataBinding.SpeedMove = 1;

        if(parent.currenttarget == null)
        {
           
            Vector3 random_Pos = parent.trans.position + new Vector3(UnityEngine.Random.Range(-3, 3), UnityEngine.Random.Range(-3, 3), UnityEngine.Random.Range(-3, 3));
            parent.dataBinding.MoveDir = random_Pos - parent.trans.position;
            parent.agent.SetDestination(random_Pos);
            
        }
    }
  

    public override void OnFixedUpdate()
    {
        if (!parent.agent.hasPath)
        {
            parent.GotoState(parent.idleState);
        }
    }
}
