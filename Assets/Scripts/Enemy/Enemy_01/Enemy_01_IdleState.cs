using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Enemy_01_IdleState : FSMState
{
    [NonSerialized]
    public Enemy_01_Control parent;
    float timeWait = 0;
    
    public override void OnEnter()
    {
        parent.dataBinding.SpeedMove = -1;
        timeWait = 5f;
    }
    public override void OnFixedUpdate()
    {
        timeWait -= Time.deltaTime;
            if (timeWait <= 0)
            {
                parent.GotoState(parent.walkState);
            }
    }
}
