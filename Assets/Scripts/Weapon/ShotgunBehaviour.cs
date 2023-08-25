using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ShotgunBehaviour : WeaponBehaviour
{
    public override void Setup(WeaponInitData data)
    {
        base.Setup(data);

        iweaponFire = new IShotgunFireHandle();
        // tao pool
    }
    IEnumerator delay(ShotgunBehaviour data)
    {

        for (int i = 0; i < data.bps; i++)
        {
            data.CreateBullet();
            yield return new WaitForSeconds(0.0000055f);
        }
    }
    public void CreateBulletDelay(ShotgunBehaviour data)
    {
        StartCoroutine(delay(data));
      
    }
}

public class IShotgunFireHandle : IWeaponFire
{
    public void OnFireHandle(object data)
    {
        ShotgunBehaviour weapon = (ShotgunBehaviour)data;

        weapon.CreateBulletDelay(weapon);
    }
    
}
