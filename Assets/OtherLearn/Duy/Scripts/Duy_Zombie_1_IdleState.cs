using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Duy_Zombie_1_IdleState : FSMState
{
    public Duy_Zombie_1_Control parent;
    public float timeDelay;

    public override void OnEnter()
    {
        parent.dataBinding.Speed = -1;
        timeDelay = UnityEngine.Random.Range(2, 4);
    }
    public override void OnFixedUpdate()
    
    {
        timeDelay -= Time.deltaTime;
        if(timeDelay<=0)
        {
            float random = UnityEngine.Random.Range(-1,3);
            if(random<=0)
            {
                parent.GotoState(parent.startState);
            }
            else
            {
                parent.GotoState(parent.runState);
            }
        }
    }
}
