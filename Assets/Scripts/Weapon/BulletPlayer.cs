using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    private WeaponBehaviour weapon;
    private Transform trans;
    public string nameImpact;
    public LayerMask mask;
   public void SetUp(WeaponBehaviour weapon)
    {
        this.weapon = weapon;
        trans = transform;
    }
    public void OnSpawned()
    {
        StartCoroutine(OnStart());
    }
    IEnumerator OnStart()
    {
        yield return new WaitForSeconds(1.5f);
       weapon.bulletPool.OnDespawned(this.transform);
    }
    public void OnDespawned()
    {
        //create impact
    }
    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * weapon.force);
        RaycastHit2D raycast = Physics2D.Raycast(trans.position, trans.up, 0.1f,mask);

        if(raycast.collider!= null)
        {
            switch (raycast.collider.tag)
            {
                case "Blood":
                    nameImpact = weapon.impact_Blood.name;
                     break;
                case "Concrete":
                    nameImpact = weapon.impact_Concrete.name;
                    break;
                case "Dirty":
                    nameImpact = weapon.impact_Dirty.name;
                    break;
                case "Metal":
                    nameImpact = weapon.impact_Metal.name;
                    break;
                default:
                    nameImpact = weapon.impact_Dirty.name;
                    break;
            }
            Transform impact = PoolManager.instance.dicPool[nameImpact].OnSpawned();
            impact.SetParent(null);
            impact.position = raycast.point;
            impact.rotation = Quaternion.identity;
            impact.GetComponent<ImpactBulletPlayer>().SetUp(nameImpact);
            impact.up = -raycast.normal;
            PoolManager.instance.dicPool[weapon.projecties.name].OnDespawned(trans);

            //tru mau
            if(raycast.collider.gameObject.layer==8)
            {
                raycast.collider.gameObject.GetComponent<EnemyControl>().OnDamage(weapon.damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(trans.position,trans.position + trans.up*0.1f);
    }
}
