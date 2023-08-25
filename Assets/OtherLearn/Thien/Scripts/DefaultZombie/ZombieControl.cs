using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControl : FSMSystem
{
    public float speedMove;
    public PolyNavAgent agent;
    public Transform trans;
    public LayerMask playerMask;
    public Transform target;
    public Vector2 dir;
    public float timeDelay;
    public float range;
    public float rof;
    public float timeAttack = 2f;
    public float attackRange = 1f;
    public float catchRange = 5f;
    public bool followOrNot = true;
    public delegate FSMState attackStateHandle();
    public attackStateHandle attackStateCallback;
    public delegate FSMState idleStateHandle();
    public idleStateHandle idleStateCallback;
    public delegate FSMState eatStateHandle();
    public eatStateHandle eatStateCallback;
    public delegate FSMState moveStateHandle();
    public moveStateHandle moveStateCallback;
    public void Setup(object data)
    {
        
    }
    public override void SystemLateUpdate()
    {
        base.SystemLateUpdate();
        timeAttack -= Time.deltaTime;
        Collider2D playerInAttackArea = Physics2D.OverlapCircle(trans.position, attackRange, playerMask);
        if(playerInAttackArea != null)
        {
            //Player trong vung Attack
            Vector2 playerPos = ((playerInAttackArea.transform.position) - trans.position).normalized;
			dir = playerPos;
			UpdateMoveDir();
            //Debug.Log(angle.ToString());
            if (timeAttack <= 0)
            {
                //Debug.Log("hit");

                if (currentState != attackStateCallback?.Invoke())
                {
                    GotoState(attackStateCallback?.Invoke());
                    timeAttack = rof;
                }

            }
        }
        else
        {
            //parent.GotoState(parent.moveStateCallback?.Invoke());
            Collider2D playerInCatchArea = Physics2D.OverlapCircle(trans.position, catchRange, playerMask);
            if (playerInCatchArea != null)
            {
                Vector2 playerPos = ((playerInCatchArea.transform.position) - trans.position).normalized;
                float angle = Vector2.Angle(playerPos, dir);
                //Player trong vung Catch
                target = playerInCatchArea.transform;
                target.position = playerInCatchArea.transform.position * 1f;
                dir = playerPos;
                UpdateMoveDir();
                
                if (currentState != moveStateCallback?.Invoke())
                {
                    GotoState(moveStateCallback?.Invoke());
                    //timeAttack = rof;
                }
            }

            else
            {
                if(target != null)
                {
                    if(!followOrNot)
                    {
                        target = null;
                        if (currentState != idleStateCallback?.Invoke())
                        {
                            GotoState(idleStateCallback?.Invoke());
                            //timeAttack = rof;
                        }
                    } 
                }
            }
        }




        //Collider2D cols = Physics2D.OverlapCircle(trans.position, catchRange, playerMask);

        //RaycastHit2D hitInfor = Physics2D.Raycast(trans.position, dir, range, playerMask);
        //timeAttack -= Time.deltaTime;
        //if (cols != null)
        //{
        //    Vector2 playerPos = ((cols.transform.position) - trans.position).normalized;
        //    float angle = Vector2.Angle(playerPos, dir);
        //    //Debug.Log(angle.ToString());
        //    if (hitInfor.collider != null && timeAttack <= 0)
        //    {
        //        //Debug.Log("hit");

        //        if (currentState != attackStateCallback?.Invoke())
        //        {
        //            GotoState(attackStateCallback?.Invoke());
        //            timeAttack = rof;
        //        }

        //    }
        //    else
        //    {
        //        if (angle < 45)
        //        {
        //            target = cols.transform;
        //            target.position = cols.transform.position * 1f;
        //            dir = playerPos;
        //            UpdateMoveDir();
                    
        //            if (timeAttack <= 0)
        //            {
        //                GotoState(moveStateCallback?.Invoke());
        //            }
        //        }
        //    }
        //}
    }
    public virtual void UpdateMoveDir()
    {
        //dataBinding.moveDir = dir;
    }
    void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(trans.position, catchRange);


        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(trans.position, attackRange);
        //Gizmos.DrawLine(trans.position, (Vector2)trans.position + dir * 2f);

    }
    public static bool NegativeOrPositive()
    {
        if(UnityEngine.Random.Range(0, 100) < 50)
        {
            return true;
        }
        return false;
    }
}
