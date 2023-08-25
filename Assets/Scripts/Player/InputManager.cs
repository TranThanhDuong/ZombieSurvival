using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputManager : Singleton<InputManager>
{
    [SerializeField]
    private JoystickInput moveJoystick;
    public Vector2 moveDir;
    public event Action OnSwapGun;
    public event Action OnReloadHandle;
    public event Action<WeaponBehaviour> OnWeaponChange;
    public event Action<bool> OnFireHandle;
    public event Action<float> OnBloodChange;
    public bool isMove = true;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void SwapGun()
    {
        OnSwapGun?.Invoke();
    }
    public void OnFire(bool isFire)
    {
        OnFireHandle?.Invoke(isFire);
    }
    public void OnReload()
    {
        OnReloadHandle?.Invoke();
    }

    public void ChangeGun(WeaponBehaviour obj)
    {
        OnWeaponChange?.Invoke(obj);
    }

    public void ChangeBlood(float blood)
    {
        OnBloodChange?.Invoke(blood);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") + moveJoystick.moveDir.x;
        float y = Input.GetAxis("Vertical") + moveJoystick.moveDir.y;
        moveDir = new Vector2(x, y);
        if(!isMove)
        {
            moveDir = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnSwapGun?.Invoke();
            if (Input.GetKeyUp(KeyCode.C))
            {
                OnSwapGun?.Invoke();
                if (Input.GetKeyUp(KeyCode.C))
                {
                    OnSwapGun?.Invoke();
                }
                else if (Input.GetKeyUp(KeyCode.C))
                {
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    OnFireHandle?.Invoke(true);
                }
                else if (Input.GetKeyUp(KeyCode.F))
                {
                    OnFireHandle?.Invoke(false);
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    OnReload();
                }
                else if (Input.GetKeyUp(KeyCode.R))
                {
                }
            }
        }
    }
}


