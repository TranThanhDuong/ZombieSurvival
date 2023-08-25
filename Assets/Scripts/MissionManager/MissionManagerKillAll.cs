using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class MissionManagerKillAll : MissionManager
{
    private int currentNumberEnemy;
    private int totalEnemyCreate;
    
    public override void Setup(ConfigMissionRecord cf)
    {
       
        base.Setup(cf);

        totalEnemyCreate = 0;
        currentNumberEnemy = 0;
        StartCoroutine("LoopCreateEnemy");
    }
    IEnumerator LoopCreateEnemy()
    {
        while(totalEnemyCreate<configMission.totalEnemy&&currentNumberEnemy<configMission.totalCurrentEnemy)
        {
            CreateEnemy();
            yield return new WaitForSeconds(1);
        }
    }
    private ConfigZombieLevelKey GetEnemyData()
    {
        List<ConfigZombieLevelKey> ls = configMission.GetEnemyMission();

        int index = Random.Range(0, ls.Count);
        return ls[index];
    }
    private Transform GetPosEnemy()
    {
       Transform[] ls = missionSceneConfig.anchor_enemies;

        int index = Random.Range(0, ls.Length);
        return ls[index];
    }
    void CreateEnemy()
    {
        ConfigZombieLevelKey data = GetEnemyData();
        ConfigZombieRecord configZombie = ConfigManager.instance.configZombie.GetRecordBykeySearch(data.id_Zombie);
        ConfigZombieLevelRecord cfZomLevel = ConfigManager.instance.ConfigZombieLevel.GetRecordBykeySearch(data);

        GameObject enemy = Instantiate(Resources.Load("Enemy/"+ configZombie.prefab, typeof(GameObject))) as GameObject;
        enemy.transform.position = GetPosEnemy().position;
        enemy.GetComponent<EnemyControl>().Setup(new EnemyCreateData { cfZomLevel = cfZomLevel, configZombie = configZombie });
        totalEnemyCreate ++;
        currentNumberEnemy++;
    }
    public override void OnObjectCollect(DataObjectCollect data)
    {
        currentNumberEnemy--;
        totalEnemydead++;
        if(totalEnemydead>=configMission.totalEnemy)
        {
            // victory 
        }
        else
        {
            if (totalEnemyCreate < configMission.totalEnemy && currentNumberEnemy < configMission.totalCurrentEnemy)
            {
                CreateEnemy();
            }
        }
        base.OnObjectCollect(data);
    }
}
