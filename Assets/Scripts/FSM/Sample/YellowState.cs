using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class YellowState : FSMState
{
    [NonSerialized]
    public TrafficLight parent;
    private float timeCount;
    public override void OnEnter()
    {
        parent.lightImage.color = Color.yellow;
        timeCount = 2;
        base.OnEnter();
    }
    public override void OnLateUpdat()
    {
        timeCount -= Time.deltaTime;
        if (timeCount <= 0)
        {
            parent.GotoState(parent.redState);
        }
        base.OnFixedUpdate();
    }
}
