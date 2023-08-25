using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataBinding : MonoBehaviour
{
    public float SpeedMove
    {
        set
        {
            animator.SetFloat(key_Speed, value);
        }
    }
    public Vector2 MoveDir
    {
        set
        {
            animator.SetFloat(key_x, value.x);
            animator.SetFloat(key_y, value.y);
        }
    }
    public bool Fire
    {
        set
        {
            if(value)
            {
                animator.SetTrigger(key_Fire);
            }
        }
    }
    public bool Reload
    {
        set
        {
            if (value)
            {
                animator.SetTrigger(key_Reload);
            }
        }
    }
    public bool Ready
    {
        set
        {
            if (value)
            {
                animator.SetTrigger(key_Ready);
            }
        }
    }
    private Animator animator;
    private int key_Speed;
    private int key_x;
    private int key_y;
    private int key_Fire;
    private int key_Reload;
    private int key_Ready;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        key_Speed = Animator.StringToHash("Speed");
        key_x = Animator.StringToHash("X");
        key_y = Animator.StringToHash("Y");
        key_Reload = Animator.StringToHash("Reload");
        key_Fire = Animator.StringToHash("Fire");
        key_Ready = Animator.StringToHash("Ready");
    }

    public void ChangeGunAnim(AnimatorOverrideController animatorOverrideController)
    {
        animator.runtimeAnimatorController = animatorOverrideController;
    }
}
