using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon 
{
    [SerializeField] protected List<Transform> minions;
    [SerializeField] protected int minionLimit = 2;


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.ClearMinionDead();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();    
    }

    protected virtual void LoadEnemySpawner()   
    {
        if (this.spawner != null) return;
        this.spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        Debug.Log(transform.name + " :LoadEnemySpawner", gameObject);
    }
    protected override void Summoning()
    {
        if(this.minions.Count >= this.minionLimit) return;
        base.Summoning();
    }

    protected override Transform Summon()
    {
        Transform minion = base.Summon();
        minion.parent = this.abilities.AbilityObjectCtrl.transform;
        this.minions.Add(minion);
        return minion;
    }


    protected virtual void ClearMinionDead()
    {
        foreach (Transform minion in this.minions) 
        {
            if (minion.gameObject.activeSelf == false)
            { 
                this.minions.Remove(minion); 
                return;
            }
        }
    }

}
