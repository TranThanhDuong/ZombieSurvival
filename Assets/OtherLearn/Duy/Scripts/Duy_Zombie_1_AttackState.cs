using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Duy_Zombie_1_AttackState : FSMState
{
    public Duy_Zombie_1_Control parent;
    public float timeDelay;
    public override void OnEnter()
    {
        parent.dataBinding.Attack = true;
        parent.GotoState(parent.startState);
    }
   
}
