using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Duy_Zombie_1_StartState : FSMState
{
    public Duy_Zombie_1_Control parent;
    private float timeDelay;
    public override void OnEnter()
    {
        parent.dataBinding.Speed = -1;
        timeDelay = parent.timeDelay;
        base.OnEnter();
    }
    public override void OnFixedUpdate()
    {
        timeDelay -= Time.deltaTime;
        if(timeDelay<=0)
        {
            parent.GotoState(parent.idleState);
        }
    }
}
