using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_02_Control : EnemyControl
{
    public Zombie_02_AttackState attackState;
    public Zombie_02_IdleState idleState;
    public Zombie_02_StartState startState;
    public Zombie_02_MoveState moveState;
    public Zombie_02_DataBinding dataBinding;
    public float rof = 3f;
    public float counter;
    public LayerMask playerMask;
    public Vector2 dir;
    public Transform target;
    public float range = 1f;


    private void Start()
    {
        trans = transform;
        Setup(null);
        counter = rof;
        dir = Vector2.up;
        agent.stoppingDistance = range;
        attackState.parent = this;
        idleState.parent = this;
        startState.parent = this;
        moveState.parent = this;
        GotoState(startState);
     
    }
    public override void Setup(EnemyCreateData data)
    {
        base.Setup(data);
    }
    public override void SystemUpdate()
    {
        Collider2D areaInfor = Physics2D.OverlapCircle(trans.position, 10f,playerMask);
        RaycastHit2D hitInfor = Physics2D.Raycast(trans.position, dir, range, playerMask);

        if (areaInfor != null)
        {
            Vector2 playerTrans = (areaInfor.transform.position - trans.position).normalized;

            if (hitInfor.collider != null && counter <= 0)
            {
                GotoState(attackState);
                counter = rof;
            }
            else
            {
                if (Mathf.Abs(Vector2.Angle(dir, playerTrans)) < 100)
                {
                    dir = playerTrans;
                    dataBinding.MoveDir = dir;
                    target = areaInfor.transform;
                    if (counter <= 0)
                    {
                        GotoState(moveState);
                    }
                }

            }
        }
        else
            target = null;
        counter -= Time.deltaTime;
    }

    public void OnAttackPlayer()
    {
        if (target == null)
            return;

        float dis = Vector3.Distance(transform.position, target.position);
        if(dis < 10)
        {
            target.GetComponent<CharacterControl>().TakeDamage(-1);
        }
    }

    public void Walk()
    {
        Vector3 pos = trans.position + new Vector3(Random.Range(-10f,10f), Random.Range(-10f, 10f), 0);
        agent.SetDestination(pos);
        Vector2 vecDir = new Vector3(pos.x, pos.y,pos.z) - trans.position;
        vecDir = vecDir.normalized;
        
        this.dir = new Vector2(Vector2.Dot(vecDir, trans.right), Vector2.Dot(vecDir, trans.up));
        dataBinding.MoveDir = dir;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(trans.position, 4f);
        Gizmos.DrawLine(trans.position, (Vector2)trans.position + dir * 2);
    }
    public override void OnDamage(int damage)
    {
        hp -= damage;
        if(hp<=0)
        {
            OnDead();
        }
    }
}
