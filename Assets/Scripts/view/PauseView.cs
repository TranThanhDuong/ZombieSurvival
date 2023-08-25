using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PauseView : BaseView
{
    public TextMeshProUGUI killLB;
    public override void OnSetup(ViewParam param)
    {
        base.OnSetup(param);
        killLB.text = ((PauseParam)param).totalKill.ToString();
        Time.timeScale = 0;
    }

    public void OnHome()
    {
        LoadingManager.instance.LoadSceneByIndex(1, () =>
        {
            ViewManager.instance.OnSwitchView(ViewIndex.HomeView);
        });
    }    

    public void OnRetry()
    {
        LoadingManager.instance.LoadSceneByIndex(2, () =>
        {
            ViewManager.instance.OnSwitchView(ViewIndex.EmptyView);
        });
    }    

    public override void OnHideView()
    {
        base.OnHideView();
        Time.timeScale = 1;
    }
}
