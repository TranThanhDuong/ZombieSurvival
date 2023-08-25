using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Thien_Zombie_03_Move : FSMState
{
    public Thien_Zombie_03_Control parent;
    private float timeDelay;
    private Vector3 targetPostion = Vector3.zero;
    private float speedMove = 1;
    private Vector3 moveDir;
    public override void OnEnter()
    {
        base.OnEnter();
        parent.databinding.Speed = 1;
        if (parent.target == null)
        {
            AutoRun();
        }
        timeDelay = UnityEngine.Random.Range(2, 4);
    }
    //IEnumerator ChangeState()
    //{
    //    yield return null;
    //}


    public override void OnFixedUpdate()
    {
        timeDelay -= Time.deltaTime;
        if (timeDelay < 0 && parent.target == null && parent.agent.activePath.Count == 0)
        {
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                parent.GotoState(parent.idleStateCallback?.Invoke());
            }
            else
            {
                parent.GotoState(parent.eatStateCallback?.Invoke());
            }
        }
        else
        {
            if (parent.target != null)
                targetPostion = parent.target.position;
        }

        moveDir = (new Vector3(targetPostion.x, targetPostion.y, targetPostion.z) - parent.trans.position).normalized;
        parent.dir = new Vector2(Vector2.Dot(moveDir, parent.trans.right), Vector2.Dot(moveDir, parent.trans.up));
        parent.UpdateMoveDir();

        //Vector3 currentPos = parent.trans.position;
        parent.agent.SetDestination(targetPostion);
        //parent.trans.position = Vector3.Lerp(parent.trans.position, parent.trans.position + moveDir * speedMove, 0.3f);

        //if (parent.target == null)
        //{
        //    if (!parent.agent.hasPath)
        //    {

        //        parent.GotoState(parent.idleStateCallback?.Invoke());

        //    }

        //}
        //else
        //{
        //    //parent.dir = ((parent.target.transform.position) - parent.trans.position).normalized;
        //    //parent.dataBinding.moveDir = parent.dir;
        //    parent.agent.SetDestination(parent.target.position);
        //}


    }
    public void AutoRun()
    {
        Vector3 pos = parent.trans.position + new Vector3(UnityEngine.Random.Range(2, 4f) *(ZombieControl.NegativeOrPositive()?-1:1),
            UnityEngine.Random.Range(2, 4f) *(ZombieControl.NegativeOrPositive()?-1:1),
            UnityEngine.Random.Range(2, 4f) *(ZombieControl.NegativeOrPositive()?-1:1));
        targetPostion = pos;
    }
}
