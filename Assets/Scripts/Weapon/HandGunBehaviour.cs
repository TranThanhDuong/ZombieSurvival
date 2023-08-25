using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunBehaviour : WeaponBehaviour
{
    public override void Setup(WeaponInitData data)
    {
        base.Setup(data);

        iweaponFire = new IHandGunFireHandle();
        // tao pool
    }
}

public class IHandGunFireHandle : IWeaponFire
{
    public void OnFireHandle(object data)
    {
        HandGunBehaviour weapon = (HandGunBehaviour)data;

        weapon.CreateBullet();
    }
}