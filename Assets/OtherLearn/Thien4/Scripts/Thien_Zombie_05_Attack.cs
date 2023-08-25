using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Thien_Zombie_05_Attack : FSMState
{
    public Thien_Zombie_05_Control parent;
    private float timeDelay = 1f;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.agent.Stop();
        parent.databinding.Attack = true;
        timeDelay = 1f;
    }
    public override void OnFixedUpdate()

    {
        timeDelay -= Time.deltaTime;

        if (timeDelay <= 0)
        {
            parent.GotoState(parent.idleStateCallback?.Invoke());
        }
    }
}