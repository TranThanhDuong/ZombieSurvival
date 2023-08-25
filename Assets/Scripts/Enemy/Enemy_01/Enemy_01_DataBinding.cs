using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_01_DataBinding : MonoBehaviour
{
    private int key_SpeedMove;
    private int key_Attack;
    private int key_X;
    private int key_Y;
    
    public Animator animator;

    public float SpeedMove
    {
        set
        {
            animator.SetFloat(key_SpeedMove, value);
        }
    }

    public bool Attack
    {
        set
        {
            if (value)
            {
                animator.SetTrigger(key_Attack);
            }
        }
    }

    

    public Vector2 MoveDir
    {
        set
        {
            animator.SetFloat(key_X, value.x);
            animator.SetFloat(key_Y, value.y);
        }
    }

   

    // Start is called before the first frame update
    void Start()
    {
        key_SpeedMove = Animator.StringToHash("Speed");
        key_Attack = Animator.StringToHash("Attack");
    
        key_X = Animator.StringToHash("X");
        key_Y = Animator.StringToHash("Y");
    }
}
