using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Thien_Zombie_04_Eat : FSMState
{
    public Thien_Zombie_04_Control parent;
    private float timeDelay;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.agent.Stop();
        parent.databinding.Speed = -1;
        parent.databinding.Eat = true;
        timeDelay = UnityEngine.Random.Range(4, 8);
        //parent.StartCoroutine("ChangeState");
    }
    public override void OnFixedUpdate()
    {
        timeDelay -= Time.deltaTime;
        if (timeDelay <= 0)
        {
            parent.GotoState(parent.idleStateCallback?.Invoke());
        }
    }
    //public override void OnExit()
    //{
    //    base.OnExit();
    //    parent.StopCoroutine("ChangeState");
    //}
    //IEnumerator ChangeState()
    //{
    //    timeDelay -= Time.deltaTime;
    //    while (timeDelay > 0)
    //    {
    //        yield return new WaitForSeconds(Time.deltaTime);
    //    }
    //    parent.databinding.Eat = false;
    //    parent.GotoState(parent.idleStateCallback?.Invoke());
    //    yield return null;
    //}
}