using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyGunBehaviour : WeaponBehaviour
{
    public override void Setup(WeaponInitData data)
    {
        base.Setup(data);

        iweaponFire = new IHeavyGunFireHandle();
        // tao pool
    }
}

public class IHeavyGunFireHandle : IWeaponFire
{
    public void OnFireHandle(object data)
    {

        HeavyGunBehaviour weapon = (HeavyGunBehaviour)data;

        weapon.CreateBullet();

    }
}