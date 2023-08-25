using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyCreateData
{
    public ConfigZombieRecord configZombie;
    public ConfigZombieLevelRecord cfZomLevel;
}
public class EnemyControl : FSMSystem
{
    public int damage;
    public int hp;
    public Transform trans;
    public PolyNavAgent agent;
    public virtual void Setup(EnemyCreateData data)
    {
        hp = 10;
    }
    public virtual void OnDamage(int damage)
    {

    }
    public  void OnDead()
    {
        Destroy(gameObject);
        // call ve mission manager
        DataObjectCollect data = new DataObjectCollect();
        data.objectType = ObjectType.Enemy;
        data.data = this;
        MissionManager.instance.OnObjectCollect(data);
    }
}
