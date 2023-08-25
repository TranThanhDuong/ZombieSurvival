using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponBehaviour : MonoBehaviour
{
    private bool isUnlimited;
    public float rof;
    public int clipSize;
    public int bulletCount;
    public int totalAmo;
    public float range;
    public float accuracy;
    public float current_accuracy;
    public float accuracy_recovery;
    public float reloadTime;
    public int damage;
    public float force=5f;
    public Transform projecties;
    public Transform impact_Blood;
    public Transform impact_Metal;
    public Transform impact_Concrete;
    public Transform impact_Dirty;
    public Transform muzzle;
    public int bps;
    public IWeaponFire iweaponFire;
    public AnimatorOverrideController animatorOverrideController;
  
    private float timeFire;
    private bool isReload;
    private bool isReady;
    public bool isFire;
    public AudioClip[] fireSFX;
    public AudioClip reloadSFX;
    public AudioClip readySFX;
    public AudioClip drySFX;
    public AudioSource audioSource;
    public WeaponInitData dataWeapon;
    public Transform aimShoot;
    public BYPool bulletPool;
    // Start is called before the first frame update
    public Action<int, int> OnAmoChangeHandle;
    public Action OnReloadHandle;
    public virtual void Setup(WeaponInitData data)
    {
        isUnlimited = true;
        dataWeapon = data;
        rof = dataWeapon.cfGunlevel.rof;
        clipSize = dataWeapon.cfGunlevel.clipSize;
        bulletCount = clipSize;
        accuracy = dataWeapon.cfGunlevel.accuracy;
        reloadTime = dataWeapon.cfGunlevel.reloadTime;
        damage = dataWeapon.cfGunlevel.damage;
        range = dataWeapon.cfGunlevel.range;
        bps = dataWeapon.cfGunlevel.bps;
        totalAmo = clipSize * 3;

        if (isUnlimited)
            totalAmo = -1;
        muzzle = dataWeapon.muzzle;
        // tao pool
      
        BYPool impact_1, impact_2, impact_3, impact_4;
        bulletPool = new BYPool();
        bulletPool.namePool = projecties.name;
        bulletPool.prefab = projecties;
        bulletPool.total = clipSize;
        PoolManager.instance.AddNewPool(bulletPool);

         impact_1 = new BYPool();
        impact_1.namePool = impact_Blood.name;
        impact_1.prefab = impact_Blood;
        impact_1.total = clipSize;
        PoolManager.instance.AddNewPool(impact_1);

         impact_2 = new BYPool();
        impact_2.namePool = impact_Metal.name;
        impact_2.prefab = impact_Metal;
        impact_2.total = clipSize;
        PoolManager.instance.AddNewPool(impact_2);

         impact_3 = new BYPool();
        impact_3.namePool = impact_Concrete.name;
        impact_3.prefab = impact_Concrete;
        impact_3.total = clipSize;
        PoolManager.instance.AddNewPool(impact_3);

         impact_4 = new BYPool();
        impact_4.namePool = impact_Dirty.name;
        impact_4.prefab = impact_Dirty;
        impact_4.total = clipSize;
        PoolManager.instance.AddNewPool(impact_4);



        ReadyGun();


    }
    public void ReadyGun()
    {
        InputManager.instance.isMove = true;
        isReady = false;
        isFire = false;
        timeFire = 0;
        isReload = false;
        OnAmoChangeHandle?.Invoke(bulletCount, totalAmo);
        dataWeapon.characterDataBinding.Ready = true;
        Invoke("DelayReady", 1f);
    }
    void DelayReady()
    {
        isReady = true;

    }
    // Update is called once per frame
    void Update()
    {
        timeFire += Time.deltaTime;
        if(isFire&&isReady)
        {
            if(timeFire>rof&& bulletCount>0&&!isReload)
            {
                iweaponFire.OnFireHandle(this);
                timeFire = 0;
                bulletCount--;
                current_accuracy += (100 - accuracy) * 0.05f;
                dataWeapon.characterDataBinding.Fire = true;
                if (bulletCount<=0)
                {
                    // reload 
                    OnReload();
                }
               
                OnAmoChangeHandle?.Invoke(bulletCount, totalAmo);
                audioSource.PlayOneShot(fireSFX[UnityEngine.Random.Range(0, fireSFX.Length)]);
            }
        }
        current_accuracy -= accuracy_recovery;
        if (current_accuracy < 0)
            current_accuracy = 0;
    }
    public void CreateBullet()
    {
        Transform bullet = PoolManager.instance.dicPool[projecties.name].OnSpawned();
     
        // Vector3 pos = muzzle.position + muzzle.up * dataWeapon.cfGunlevel.range;
        float random = current_accuracy * UnityEngine.Random.Range(-1f, 1f);
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, random));
        Vector3 dir = q*aimShoot.up;
        bullet.position = aimShoot.position + dir;
        bullet.up = dir;
        bullet.GetComponent<BulletPlayer>().SetUp(this);

    }
    public void OnReload()
    {
        if(bulletCount>=clipSize)
        {
            return;
        }
        
        if (totalAmo<=0 && !isUnlimited)
        {
            return;
        }
       

        StopCoroutine("ReloadProgess");
        StartCoroutine("ReloadProgess");
    }
    IEnumerator ReloadProgess()
    {
        isReload = true;
        InputManager.instance.isMove = false;
        dataWeapon.characterDataBinding.Reload = true;
        yield return new WaitForSeconds(reloadTime);
        isReload = false;
        InputManager.instance.isMove = true;
        // tinh bullet 

        int numberBulletNeed = clipSize - bulletCount;

        if(!isUnlimited)
        {
            if (numberBulletNeed > totalAmo)
            {
                numberBulletNeed = totalAmo;
                totalAmo = 0;

            }
            else
            {
                totalAmo -= numberBulletNeed;
            }
        }    
        
        bulletCount += numberBulletNeed;
        OnAmoChangeHandle?.Invoke(bulletCount, totalAmo);
    }
}
