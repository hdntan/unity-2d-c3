using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }

    public static string EnemyOne = "Enemy_1";



    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.LogError("Only 1 EnemySpawner allow to exits");
        EnemySpawner.instance = this;
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion roatation)
    {

        Transform newEnemy = base.Spawn(prefab, spawnPos, roatation);
        this.AddHpBar2Enemy(newEnemy);  
       
        return newEnemy;
    }

    protected virtual void AddHpBar2Enemy(Transform newEnemy)
    {
        ShootableObjectCtrl enemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();
        Transform newHpBar = HpBarSpawner.Instance.Spawn(HpBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
        HpBar hpBar = newHpBar.GetComponent<HpBar>();
        hpBar.SetShootableObjectCtrl(enemyCtrl);
        hpBar.SetFollowTarget(newEnemy);

        newHpBar.gameObject.SetActive(true);
       

    }
}
