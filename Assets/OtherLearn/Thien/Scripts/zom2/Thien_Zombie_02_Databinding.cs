using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thien_Zombie_02_Databinding : MonoBehaviour
{
    public Animator animator;
    private int key_Attack, key_X, key_Y, key_Eat, key_Speed;
    // Start is called before the first frame update
    public Vector2 moveDir
    {
        set
        {
            animator.SetFloat(key_X, value.x);
            animator.SetFloat(key_Y, value.y);
        }
    }
    public bool Attack
    {
        set
        {
            animator.SetTrigger(key_Attack);
        }
    }
    public float Speed
    {
        set
        {
            animator.SetFloat(key_Speed, value);
        }
    }
    public bool Eat
    {
        set
        {
            if (value)
                animator.SetTrigger(key_Eat);
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        key_Speed = Animator.StringToHash("Speed");
        key_Attack = Animator.StringToHash("Attack");
        key_X = Animator.StringToHash("X");
        key_Y = Animator.StringToHash("Y");
        key_Eat = Animator.StringToHash("Eat");
    }

}
