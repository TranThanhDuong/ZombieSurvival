using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    public List<BYPool> pools;
    public Dictionary<string, BYPool> dicPool = new Dictionary<string, BYPool>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(BYPool pool in pools)
        {
            CreatePrefab(pool);
            dicPool[pool.namePool] = pool;
            //dicPool.Add(pool.namePool, pool);
        }
    }
    public void AddNewPool(BYPool pool)
    {
        if(!dicPool.ContainsKey(pool.namePool))
        {
            for (int i = 0; i < pool.total; i++)
            {
                Transform trans = Instantiate(pool.prefab, Vector3.zero, Quaternion.identity);
                pool.elements.Add(trans);
                trans.gameObject.SetActive(false);
            }
            dicPool[pool.namePool] = pool;
        }
        else
        {
            int numNeed = pool.total - dicPool[pool.namePool].elements.Count;

            if (numNeed > 0)
            {
                for (int i = 0; i < numNeed; i++)
                {
                    Transform trans = Instantiate(pool.prefab, Vector3.zero, Quaternion.identity);
                    dicPool[pool.namePool].elements.Add(trans);
                    trans.gameObject.SetActive(false);
                }
            }
            
        }
    }
    public void CreatePrefab(BYPool pool )
    {
   
        for (int i = 0; i < pool.total; i++)
        {
            Transform trans = Instantiate(pool.prefab, Vector3.zero, Quaternion.identity);
            pool.elements.Add(trans);
            trans.gameObject.SetActive(false);
        }
       
    }

}


