using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Thien_Zombie_04_Idle : FSMState
{
    public Thien_Zombie_04_Control parent;
    private float timeDelay;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.agent.Stop();
        //agent.activePath.Clear();
        parent.databinding.Speed = -1;
        timeDelay = UnityEngine.Random.Range(5, 9);
    }
    public override void OnFixedUpdate()

    {
        timeDelay -= Time.deltaTime;
        if (parent.target != null)
        {
            parent.GotoState(parent.attackStateCallback?.Invoke());
        }
        else
        {
            if (timeDelay <= 0)
            {
                parent.GotoState(parent.moveStateCallback?.Invoke());
            }
        }
    }
}
