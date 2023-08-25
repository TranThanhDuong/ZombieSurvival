using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duy_Zombie_1_DataBinding : MonoBehaviour
{

    public Animator anim;
    private int key_X;
    private int key_Y;
    private int key_Attack;
    private int key_Speed;
    private int key_Eat;

    public Vector2 moveDir
    {
        set
        {
            anim.SetFloat(key_X, value.x);
            anim.SetFloat(key_Y, value.y);
        }
    }
    public bool Attack
    {
        set
        {
            anim.SetTrigger(key_Attack);
        }
    }
    public float Speed
    {
        set
        {
            anim.SetFloat(key_Speed, value);
        }
    }
    public bool Eat
    {
        set
        {
            anim.SetTrigger(key_Eat);
        }
    }
    void Start()
    {
        key_Speed = Animator.StringToHash("Speed");
        key_Attack = Animator.StringToHash("Attack");
        key_X = Animator.StringToHash("X");
        key_Y = Animator.StringToHash("Y");
        key_Eat = Animator.StringToHash("Eat");
    }
}
