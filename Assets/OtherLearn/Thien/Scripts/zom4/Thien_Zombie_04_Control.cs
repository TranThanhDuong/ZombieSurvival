using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thien_Zombie_04_Control : ZombieControl
{
    public Thien_Zombie_04_Databinding databinding;
    public Thien_Zombie_04_Attack attackState;
    public Thien_Zombie_04_Idle idleState;
    public Thien_Zombie_04_Move moveState;
    public Thien_Zombie_04_Eat eatState;
    // Start is called before the first frame update
    void Start()
    {
        databinding = GetComponent<Thien_Zombie_04_Databinding>();

        idleState.parent = this;
        AddState(idleState);

        attackState.parent = this;
        AddState(attackState);

        moveState.parent = this;
        AddState(moveState);

        eatState.parent = this;
        AddState(eatState);
        attackStateCallback += () => attackState;
        moveStateCallback += () => moveState;
        idleStateCallback += () => idleState;
        eatStateCallback += () => eatState;
    }
    public override void UpdateMoveDir()
    {
        base.UpdateMoveDir();
        databinding.moveDir = dir;
    }
}
