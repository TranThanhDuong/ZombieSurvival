using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGunBehaviour : WeaponBehaviour
{
    public override void Setup(WeaponInitData data)
    {
        base.Setup(data);

        iweaponFire = new IAutoGunFireHandle();
        // tao pool
    }
}

public class IAutoGunFireHandle : IWeaponFire
{
    public void OnFireHandle(object data)
    {
        AutoGunBehaviour weapon = (AutoGunBehaviour)data;

        weapon.CreateBullet();
    }
}