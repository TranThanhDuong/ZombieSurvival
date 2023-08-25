using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class ConfigGunLevelRecord
{
    //id,idGun,level,damage,rof,clipSize,range,accuracy,bps,reloadTime,costUpgrade
    public int id;
    public int idGun;
    public int level;
    public int damage;
    public float rof;
    public int clipSize;
    public float range;
    public float accuracy;
    public int bps;
    public float reloadTime;
    public int costUpgrade;
}

public class ConfigGunLevelKey
{
    public int idGun;
    public int level;
}

public class ConfigGunLevelComparison : ConfigCompare<ConfigGunLevelRecord>
{
    public override int ICompareHandle(ConfigGunLevelRecord x, ConfigGunLevelRecord y)
    {
        if(x.idGun > y.idGun)
        {
            return 1;
        }
        else if(x.idGun < y.idGun)
        {
            return -1;
        }
        else
        {
            if(x.level > y.level)
            {
                return 1;
            }
            else if(x.level < y.level)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public override ConfigGunLevelRecord SetkeySearch(object key)
    {
        ConfigGunLevelKey newKey = (ConfigGunLevelKey)key;
        ConfigGunLevelRecord data = new ConfigGunLevelRecord();
        data.idGun = newKey.idGun;
        data.level = newKey.level;
        return data;
    }
}

public class ConfigGunLevel : BYDataTable<ConfigGunLevelRecord>
{
    public override void InitComparison()
    {
        recordCompare = new ConfigGunLevelComparison();
    }
   
}

