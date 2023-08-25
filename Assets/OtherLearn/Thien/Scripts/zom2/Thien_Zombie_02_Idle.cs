using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Thien_Zombie_02_Idle : FSMState
{
    public Thien_Zombie_02_Control parent;
    private float timeDelay;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.agent.Stop();
        //agent.activePath.Clear();
        parent.databinding.Speed = -1;
        timeDelay = UnityEngine.Random.Range(3, 6);
    }
    public override void OnFixedUpdate()

    {
        timeDelay -= Time.deltaTime;
        if (parent.target != null)
        {
            parent.GotoState(parent.attackStateCallback?.Invoke());
        }
        else {
            if (timeDelay <= 0)
            {
                float random = UnityEngine.Random.Range(-1, 3);
                if (random <= 0)
                {
                    parent.GotoState(parent.moveStateCallback?.Invoke());
                }
                else
                {
                    parent.GotoState(parent.eatStateCallback?.Invoke());
                }
            }
        }
    }
}
