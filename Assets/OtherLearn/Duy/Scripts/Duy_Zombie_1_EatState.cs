using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Duy_Zombie_1_EatState : FSMState
{
    public Duy_Zombie_1_Control parent;
    public float timeDelay;

    public override void OnEnter()
    {
        parent.dataBinding.Speed = -1;
        parent.dataBinding.Eat = true;
        timeDelay = UnityEngine.Random.Range(2, 4);
    }
    public override void OnFixedUpdate()

    {
        timeDelay -= Time.deltaTime;
        if (timeDelay <= 0)
        {
            parent.dataBinding.Eat = false;
            parent.GotoState(parent.startState);            
        }
    }
}