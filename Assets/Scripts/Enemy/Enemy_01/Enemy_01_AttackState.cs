using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Enemy_01_AttackState : FSMState
{
    [NonSerialized]
    public Enemy_01_Control parent;
    public override void OnEnter()
    {
        parent.dataBinding.Attack = true;
        parent.dataBinding.SpeedMove = -1;
        parent.GotoState(parent.idleState);


    }
    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        
    }
}
