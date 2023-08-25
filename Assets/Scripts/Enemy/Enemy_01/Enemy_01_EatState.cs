using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Enemy_01_EatState : FSMState
{
    [NonSerialized]
    public Enemy_01_Control parent;

    public override void OnEnter()
    {
        base.OnEnter();
        

    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        if (parent.currenttarget != null)
        {
            Debug.LogError(parent.currenttarget);
            
            parent.GotoState(parent.walkState);
        }
    }
}
