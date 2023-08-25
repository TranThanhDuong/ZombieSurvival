using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIIngame : MonoBehaviour
{
    public Image iconGun;
    public Text gunInfo;
    private WeaponBehaviour currentWeapon;
    public Image health_Image;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.instance.OnWeaponChange+= WeaponControl_OnWeaponChange;
        InputManager.instance.OnBloodChange += OnBloodChange;
    }

    void WeaponControl_OnWeaponChange(WeaponBehaviour obj)
    {
        if(currentWeapon!=null)
        {
            currentWeapon.OnAmoChangeHandle -= OnAmoChangeHandle;
        }
        currentWeapon = obj;

        Sprite sprite = Resources.Load("Icon/" + currentWeapon.dataWeapon.cfGun.icon, typeof(Sprite)) as Sprite;
        iconGun.overrideSprite = sprite;
        currentWeapon.OnAmoChangeHandle += OnAmoChangeHandle;
       // OnAmoChangeHandle(currentWeapon.bulletCount, currentWeapon.totalAmo);
    }

    void OnAmoChangeHandle(int current, int total)
    {
        if (total != -1)
            gunInfo.text = current.ToString() + "/" + total.ToString();
        else
            gunInfo.text = current.ToString() + "/∞";
    }

    void OnBloodChange(float blood)
    {
        health_Image.fillAmount = blood;
    }

    public void OnSwapGun()
    {
        InputManager.instance.SwapGun();
    }
    public void OnReloadGun()
    {
        InputManager.instance.OnReload();
    }
    public void OnFire(bool isFire)
    {
        InputManager.instance.OnFire(isFire);
    }

    public void OnPauseGame()
    {
        PauseParam p = new PauseParam();
        p.totalKill = MissionManager.instance.TotalEnemyDead;
        ViewManager.instance.OnSwitchView(ViewIndex.PauseView, p);
    }    
}
