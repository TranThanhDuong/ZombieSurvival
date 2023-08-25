using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ConfigZombieLevelRecord
{
    //id,level,id_Zombie,damage,rof,speed
    public int id;
    public int id_Zombie;
    public int level;
    public int damage;
    public int hp;
    public float rof;
    public int detectRange;
}
public class ConfigZombieLevelKey
{
    public int id_Zombie;
    public int level;
}
public class ConfigZombieLevelComparison : ConfigCompare<ConfigZombieLevelRecord>
{
    public override int ICompareHandle(ConfigZombieLevelRecord x, ConfigZombieLevelRecord y)
    {
        if (x.id_Zombie > y.id_Zombie)
        {
            return 1;
        }
        else if (x.id_Zombie < y.id_Zombie)
        {
            return -1;
        }
        else
        {
            if (x.level > y.level)
            {
                return 1;
            }
            else if (x.level < y.level)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    public override ConfigZombieLevelRecord SetkeySearch(object key)
    {
        ConfigZombieLevelKey newKey = (ConfigZombieLevelKey)key;
        ConfigZombieLevelRecord data = new ConfigZombieLevelRecord();
        data.id_Zombie = newKey.id_Zombie;
        data.level = newKey.level;
        return data;
    }
}
public class ConfigZombieLevel : BYDataTable<ConfigZombieLevelRecord>
{
    public override void InitComparison()
    {
        recordCompare = new ConfigZombieLevelComparison();
    }
}
