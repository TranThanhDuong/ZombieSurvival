using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RedState : FSMState
{
    [NonSerialized]
    public TrafficLight parent;
    private float timeCount;
    public override void OnEnter()
    {
        parent.lightImage.color = Color.red;
        timeCount = 10;
        base.OnEnter();
    }
    public override void OnLateUpdat()
    {
        timeCount -= Time.deltaTime;
        if (timeCount <= 0)
        {
            parent.GotoState(parent.greenState);
        }
        base.OnFixedUpdate();
    }
}
