using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_01_Control : EnemyControl
{
    public Enemy_01_DataBinding dataBinding;
    public Enemy_01_IdleState idleState;
    public Enemy_01_WalkState walkState;
    public Enemy_01_AttackState attackState;
    public Enemy_01_EatState eatState;

    public Transform currenttarget;

    
    public LayerMask mask;
    public float timeAttack;
    public int rof;
    public Vector2 dir;
    

    public Vector2 playerTrans;
    

    private void Start()
    {
        timeAttack = 1;
        rof = 2;
        trans = transform;
        dir = Vector2.up;
       
        idleState.parent = this;
        AddState(idleState);

        eatState.parent = this;
        AddState(eatState);

        walkState.parent = this;
        AddState(walkState);


        attackState.parent = this;
        AddState(attackState);

        GotoState(eatState);
    }

    public override void SystemUpdate()
    {
        timeAttack += Time.deltaTime;
    }


    public override void SystemFixedUpdate()
    {
        Collider2D areaFollow = Physics2D.OverlapCircle(trans.position, 3f, mask);
        RaycastHit2D hit = Physics2D.Raycast(trans.position, dir, 1.5f, mask);
        
        if (areaFollow != null)
        {
            
            playerTrans = (areaFollow.transform.position - trans.position).normalized;
            

            if (hit.collider != null)
            {
                if (timeAttack >= rof)
                {
                    if (currentState != attackState)
                    {
                        
                            GotoState(attackState);
                            timeAttack = 0;
                        
                    }
                }
            }
            else
            {
                dir = playerTrans;
                currenttarget = areaFollow.transform;
                dataBinding.MoveDir = playerTrans;
                GotoState(walkState);
                agent.SetDestination(currenttarget.position);
            }
            
        }
        
        currenttarget = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(trans.position, 3f);
        Gizmos.DrawLine(trans.position, trans.position + Vector3.up * 1.5f);
    }
}
