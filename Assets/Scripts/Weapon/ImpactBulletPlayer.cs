using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactBulletPlayer : MonoBehaviour
{
    public WeaponBehaviour weapon;
    public ParticleSystem particle_;
    public string namePool;
    [SerializeField]
    private AudioSource audioS;
    [SerializeField]
    private AudioClip[] sfxs;
    public void SetUp(WeaponBehaviour weapon)
    {
        this.weapon = weapon;
    }
    public void SetUp(string namePool)
    {
        this.namePool = namePool;
    }
    IEnumerator OnStart()
    {
        yield return new WaitForSeconds(0.5f);
        PoolManager.instance.dicPool[namePool].OnDespawned(this.transform);
    }
    public void OnSpawned()
    {
        particle_.Play();
        StartCoroutine(OnStart());
        audioS.PlayOneShot(sfxs[UnityEngine.Random.Range(0, sfxs.Length)]);
    }
    public void OnDespawned()
    {

    }
}
