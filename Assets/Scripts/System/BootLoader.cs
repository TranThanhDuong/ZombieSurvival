using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootLoader : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    private void Start()
    {
        ConfigManager.instance.InitConfig(() =>
        {
            LoadingManager.instance.LoadSceneByIndex(1, () =>
            {
                ViewManager.instance.OnSwitchView(ViewIndex.HomeView);
            });
        });
    }

}