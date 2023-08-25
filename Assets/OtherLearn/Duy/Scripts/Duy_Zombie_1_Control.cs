using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Duy_Zombie_1_Control : FSMSystem
{
    public Duy_Zombie_1_DataBinding dataBinding;
    public Duy_Zombie_1_StartState startState;
    public Duy_Zombie_1_IdleState idleState;
    public Duy_Zombie_1_RunState runState;
    public Duy_Zombie_1_AttackState attackState;
    public Duy_Zombie_1_DeadState deadState;
    public Duy_Zombie_1_EatState eatState;
    public PolyNavAgent agent;
    public Transform trans;
    public LayerMask playerMask;
    public Transform target;
    public Vector2 dir;
    public float timeDelay;
    public float range;
    public float rof;
    public float timeAttack;
    void Start()
    {
        rof = 3f;
        timeAttack = rof;
        trans = transform;
        dir = Vector2.up;
        timeDelay = 2f;
        range = 1f;
        attackState.parent = this;
        startState.parent = this;
        idleState.parent = this;
        runState.parent = this;
        eatState.parent = this;
        GotoState(startState);
    }


    public override void SystemUpdate()
    {
        Collider2D cols = Physics2D.OverlapCircle(trans.position, 5f, playerMask);

        RaycastHit2D hitInfor = Physics2D.Raycast(trans.position, dir, range, playerMask);
        timeAttack -= Time.deltaTime;
        if(cols!=null)
        {
            Vector2 playerPos = ((cols.transform.position) - trans.position).normalized;
            float angle = Vector2.Angle(playerPos, dir);
            //Debug.Log(angle.ToString());
            if (hitInfor.collider != null && timeAttack <= 0)
            {
                //Debug.Log("hit");

                if (currentState != attackState)
                {
                    GotoState(attackState);
                    timeAttack = rof;
                }

            }
            else
            {
                if (angle < 45)
                {
                    target = cols.transform;
                    target.position = cols.transform.position * 1f;
                    dir = playerPos;
                    dataBinding.moveDir = dir;
                    if (timeAttack <= 0)
                    {
                        GotoState(runState);
                    }
                }
            }
        }
    }
    public void AutoRun()
    {
        Vector3 pos = trans.position + new Vector3(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f));
        agent.SetDestination(pos);
        Vector2 moveDir = new Vector3(pos.x,pos.y,pos.z) - trans.position;
        this.dir = new Vector2(Vector2.Dot(moveDir, trans.right), Vector2.Dot(moveDir, trans.up));
        dataBinding.moveDir = dir;
    }
    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(trans.position,5f);
        Gizmos.DrawLine(trans.position,(Vector2)trans.position+dir*2f);
            
    }
}
