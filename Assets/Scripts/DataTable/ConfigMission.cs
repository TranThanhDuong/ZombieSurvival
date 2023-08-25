using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum MissionType
{
    KillAll=1,
    Defend=2,
    Collect=3

}
[Serializable]
public class ConfigMissionRecord
{
    //id,scene_name,scene_Config,mode,id_Item,time_Mission,enemies,reward
    public int id;
    public string scene_name;
    public string scene_Config;
    public MissionType mode;
    public int id_Item;
    public float time_Mission;
    [SerializeField]
    private string enemies;
    public List<ConfigZombieLevelKey> GetEnemyMission()
    {
        List<ConfigZombieLevelKey> ls = new List<ConfigZombieLevelKey>();
       string[] s1 = enemies.Split(';');
        foreach(string e in s1)
        {
            string[] s = e.Split('-');
            ConfigZombieLevelKey key = new ConfigZombieLevelKey();
            key.id_Zombie = int.Parse(s[0]);
            key.level = int.Parse(s[1]);
            ls.Add(key);
        }
        return ls;
    }
    public int totalCurrentEnemy;
    public int totalEnemy;
    public string reward;
}
public class ConfigMission : BYDataTable<ConfigMissionRecord>
{
    public override void InitComparison()
    {
        recordCompare=  new ConfigPrimarykeyCompare<ConfigMissionRecord>("id");
    }
}
