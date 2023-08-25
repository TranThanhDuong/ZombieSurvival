using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfigManager : Singleton<ConfigManager>
{

    private ConfigGun configGun_;
    public ConfigGun configGun
    {
        get
        {
            return configGun_;
        }
    }

    private ConfigGunLevel configGunLevel_;
    public ConfigGunLevel configGunLevel
    {
        get
        {
            return configGunLevel_;
        }
    }
    private ConfigZombie configZombie_;
    public ConfigZombie configZombie
    {
        get
        {
            return configZombie_;
        }
    }
    private ConfigZombieLevel configZombieLevel_;
    public ConfigZombieLevel ConfigZombieLevel
    {
        get
        {
            return configZombieLevel_;
        }
    }
    private ConfigMission configMission_;
    public ConfigMission configMission
    {
        get
        {
            return configMission_;
        }
    }

    public void InitConfig(Action callback)
    {
        StartCoroutine(Init(callback));
    }
    IEnumerator Init(Action callback)
    {
       
        configGun_ = Resources.Load("DataTable/ConfigGun", typeof(ScriptableObject)) as ConfigGun;
        yield return new WaitUntil(() => configGun_ != null);
        configGunLevel_ = Resources.Load("DataTable/ConfigGunLevel", typeof(ScriptableObject)) as ConfigGunLevel;
        yield return new WaitUntil(() => configGunLevel_ != null);
        configZombie_ = Resources.Load("DataTable/ConfigZombie", typeof(ScriptableObject)) as ConfigZombie;
        yield return new WaitUntil(() => configZombie_ != null);
        configZombieLevel_ = Resources.Load("DataTable/ConfigZombieLevel", typeof(ScriptableObject)) as ConfigZombieLevel;
        yield return new WaitUntil(() => configZombieLevel_ != null);

        configMission_ = Resources.Load("DataTable/ConfigMission", typeof(ScriptableObject)) as ConfigMission;
        yield return new WaitUntil(() => configMission_ != null);
        callback?.Invoke();     
    }
   
}
