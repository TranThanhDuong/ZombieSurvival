using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GreenState : FSMState
{
    [NonSerialized]
    public TrafficLight parent;
    private float timeCount;
    public override void OnEnter()
    {
        parent.lightImage.color = Color.green;
        timeCount = 3;
        base.OnEnter();
    }
    public override void OnFixedUpdate()
    {

        base.OnFixedUpdate();
    }
    public override void OnUpdate()
    {
        timeCount -= Time.deltaTime;
        if (timeCount <= 0)
        {
            parent.GotoState(parent.yellowState);
        }
    }
}
