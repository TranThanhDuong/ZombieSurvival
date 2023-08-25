using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem : MonoBehaviour
{
    public FSMState currentState;
    public void AddState(FSMState newState)
    {
        if(currentState==null)
        {
            currentState = newState;
            currentState.OnEnter();
        }
    }
    public void GotoState(FSMState newState)
    {
        if(currentState!=null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter();
    }
    public void GotoState(FSMState newState, object data)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter(data);
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate();
        }
        SystemUpdate();
    }

    private void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.OnLateUpdat();
        }
        SystemLateUpdate();
    }
    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.OnFixedUpdate();
        }
        SystemFixedUpdate();
    }
    public virtual void SystemUpdate()
    {

    }
    public virtual void SystemLateUpdate()
    {

    }
    public virtual void SystemFixedUpdate()
    {

    }
}
