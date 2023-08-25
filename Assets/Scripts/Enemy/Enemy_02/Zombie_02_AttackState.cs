using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Zombie_02_AttackState : FSMState
{
    public Zombie_02_Control parent;
    
    public override void OnEnter()
    {
        parent.dataBinding.Key_Attack = true;
        parent.GotoState(parent.idleState);
        parent.OnAttackPlayer();
    }
}
