using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Enemy=1,
    Item=2

}
public class DataObjectCollect
{
    public ObjectType objectType;
    public object data;
}
public class MissionManager : Singleton<MissionManager>
{
    public MissionSceneConfig missionSceneConfig;
    public ConfigMissionRecord configMission;
    protected int totalEnemydead;
    public int TotalEnemyDead => totalEnemydead;
    public virtual void Setup(ConfigMissionRecord cf)
    {
        configMission = cf;
        GameObject goMissionConfig = Instantiate(Resources.Load("Mission/Config/" + cf.scene_Config, typeof(GameObject))) as GameObject;
        missionSceneConfig = goMissionConfig.GetComponent<MissionSceneConfig>();
        // tao player
        GameObject player = Instantiate(Resources.Load("Player/Logic", typeof(GameObject))) as GameObject;
        player.transform.position = missionSceneConfig.anchor_Player.position;
        totalEnemydead = 0;
    }
    public void CreatePlayer(Transform trans_)
    {

    }
    public void CreateEnemy(Transform trans_)
    {

    }

    public virtual void OnObjectCollect(DataObjectCollect data)
    {

    }
}
