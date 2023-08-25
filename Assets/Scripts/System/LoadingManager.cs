using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using TMPro;

public class LoadingManager : Singleton<LoadingManager>
{
    public GameObject loadingView;
    private Coroutine coroutine_;
    public Image progress;
    public TextMeshProUGUI progressLB;
    private Action action;
    private float m_count;
    WaitForSeconds wait = new WaitForSeconds(0.001f);
    AsyncOperation progress_;
    public void LoadSceneByIndex(int index, Action callBack, bool coroutine = false)
    {
        //if (coroutine_ != null)
        //{
        //    StopCoroutine(coroutine_);
        //}
        //coroutine_ = StartCoroutine(LoadingSceneIndex(index, calBack));

        loadingView.SetActive(true);
        progress_ = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        action = callBack;
    }
    IEnumerator LoadingSceneIndex(int index, Action callback)
    {
        loadingView.SetActive(true);
        progress_ = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        float count = 0;
        while (!progress_.isDone)
        {
            count += 0.01f;
            if (count > 0.5f)
            {
                count = 0.5f;
                if (progress_.progress > 0.5f)
                    count = progress_.progress;
            }

            progress.fillAmount = count;
            progressLB.text = Mathf.RoundToInt(count * 100).ToString() + "%";
            yield return wait;
        }
        progress.fillAmount = 1;
        progressLB.text = "100%";
        yield return new WaitForSeconds(1);
        callback?.Invoke();
        loadingView.SetActive(false);
    }
    private void Update()
    {
        if (progress_ != null)
        {
            if(!progress_.isDone)
            {
                m_count += 0.01f;
                if (m_count > 0.5f)
                {
                    m_count = 0.5f;
                    if (progress_.progress > 0.5f)
                        m_count = progress_.progress;
                }

                progress.fillAmount = m_count;
                progressLB.text = Mathf.RoundToInt(m_count * 100).ToString() + "%";
            }
            else
            {
                progress.fillAmount = 1;
                progressLB.text = "100%";
                action?.Invoke();
                loadingView.SetActive(false);
                progress_ = null;
                action = null;
                m_count = 0;
            }
        }
        //    Debug.LogError("o là lá: " + progress_.isDone);


    }
}
