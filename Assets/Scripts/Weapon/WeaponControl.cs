using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponInitData
{
    public Transform muzzle;
    public ConfigGunRecord cfGun;
    public ConfigGunLevelRecord cfGunlevel;
    public CharacterDataBinding characterDataBinding;
}
public class WeaponControl : MonoBehaviour
{
    public Transform anchorGun;
    public CharacterDataBinding characterDataBinding;
    private WeaponBehaviour currentWeapon;
    private List<WeaponBehaviour> weapons= new List<WeaponBehaviour>();
    private int indexGun;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        //
        InputManager.instance.OnSwapGun += OnChangeGun;
        indexGun = -1;
      
        foreach (int id in ConfigManager.instance.configGun.GetAllID())
        {

            ConfigGunRecord cfGun = ConfigManager.instance.configGun.GetRecordBykeySearch(id);
            ConfigGunLevelRecord cfGunlevel = ConfigManager.instance.configGunLevel.
            GetRecordBykeySearch(new ConfigGunLevelKey { idGun = id, level = 1 });


            GameObject gun = Instantiate(Resources.Load("Weapon/" + cfGun.name, typeof(GameObject))) as GameObject;
            gun.transform.SetParent(anchorGun, false);
            WeaponBehaviour wp = gun.GetComponent<WeaponBehaviour>();
            WeaponInitData data = new WeaponInitData();
            data.muzzle = anchorGun;
            data.cfGun = cfGun;
            data.cfGunlevel = cfGunlevel;
            data.characterDataBinding = characterDataBinding;
            wp.Setup(data);
            weapons.Add(wp);
            gun.SetActive(false);
        }
        OnChangeGun();
        InputManager.instance.OnFireHandle += (bool obj) => {

            currentWeapon.isFire = obj;
            InputManager.instance.isMove = !obj;
        };
        InputManager.instance.OnReloadHandle += () => {

            currentWeapon.OnReload();
        };
    }

    public void OnChangeGun()
    {
        indexGun++;
        if (indexGun >= weapons.Count)
            indexGun = 0;
        currentWeapon = weapons[indexGun];
        characterDataBinding.ChangeGunAnim(currentWeapon.animatorOverrideController);
        currentWeapon.gameObject.SetActive(true);
        InputManager.instance.ChangeGun(currentWeapon);
        currentWeapon.ReadyGun();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
