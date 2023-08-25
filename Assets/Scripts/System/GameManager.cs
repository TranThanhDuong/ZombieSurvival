using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        bool isLoad = false;
        ConfigManager.instance.InitConfig(() =>
        {
            isLoad = true;
        });
        yield return new WaitUntil(() => isLoad);
        ConfigMissionRecord configMission = ConfigManager.instance.configMission.GetRecordBykeySearch(1);
        //1. load scence 
        //2. tao mission mamanger 
        GameObject goMission = null;
        string nameMode = string.Empty;
        if(configMission.mode==MissionType.KillAll)
        {
            nameMode = "MissionManager_KillAll";
        }
        else if(configMission.mode == MissionType.Defend)
        {
            nameMode = "MissionManager_Defend";
        }
        else if (configMission.mode == MissionType.Collect)
        {
            nameMode = "MissionManager_Collect";
        }
        goMission = Instantiate(Resources.Load("Mission/Mode/"+ nameMode, typeof(GameObject))) as GameObject;
        goMission.GetComponent<MissionManager>().Setup(configMission);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
