using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Zombie_02_IdleState: FSMState
{
    public Zombie_02_Control parent;
    private float timeDelay;
    public override void OnEnter()
    {
        parent.dataBinding.Key_SpeedMove = -1;
        parent.dataBinding.Key_Start = false;
        timeDelay = UnityEngine.Random.Range(2, 4);
    }

    public override void OnUpdate()
    {
        if (parent.target == null)
        {

            if (timeDelay <= 0)
            {
                float rand = UnityEngine.Random.Range(-1, 2);
                if (rand <= 0)
                {
                    parent.GotoState(parent.startState);
                }
                else
                {
                    parent.GotoState(parent.moveState);
                }

            }
            timeDelay -= Time.deltaTime;
        }
        else
        {

        }
    }
}