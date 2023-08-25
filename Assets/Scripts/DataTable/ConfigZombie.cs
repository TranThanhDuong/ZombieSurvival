using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
    public enum ZombieType
    {
        SLOW_ZOMBIE = 1,
        RAPID_ZOMBIE =2,
        SKULL_ZOMBIE = 3,
        MUTANT_ZOMBIE = 4

    }
    [Serializable]
    public class ConfigZombieRecord
    {
    //id_Zombie,name,zombieType
        public int id;
        public string name;
        public string prefab;
        public ZombieType zombieType;

    }
public class ConfigZombie : BYDataTable<ConfigZombieRecord>
{
    public override void InitComparison()
    {
        recordCompare = new ConfigPrimarykeyCompare<ConfigZombieRecord>("id");
    }
    public List<int> GetAllID()
    {
        int[] ids = records
                     .Select(i => i.id)
                     .ToArray();

        List<int> ls = new List<int>();
        ls.AddRange(ids);
        return ls;
    }
}

