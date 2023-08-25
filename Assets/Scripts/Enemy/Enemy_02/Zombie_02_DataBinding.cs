using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_02_DataBinding : MonoBehaviour
{

    public Animator anim;
    private int key_Attack;
    private int key_IsStart;
    private int key_SpeedMove;
    private int key_X;
    private int key_Y;

    public Vector2 MoveDir
    {
        set
        {

            anim.SetFloat(key_X, value.x);
            anim.SetFloat(key_Y, value.y);
        }
    }
    public bool Key_Attack
    {
        set
        {
            if(value)
            {
                anim.SetTrigger(key_Attack);
            }
        }
    }
    public bool Key_Start
    {
        set
        {
            anim.SetBool(key_IsStart, value);
        }
    }
    public float Key_SpeedMove
    {
        set
        {
            anim.SetFloat(key_SpeedMove, value);
        }
    }

    void Start()
    {
        key_SpeedMove = Animator.StringToHash("SpeedMove");
        key_Attack = Animator.StringToHash("Attack");
        key_IsStart = Animator.StringToHash("IsStart");
        key_X = Animator.StringToHash("X");
        key_Y= Animator.StringToHash("Y");
    }

}
