using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability Summon")]
    [SerializeField] protected Spawner spawner;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }

    protected virtual void Summoning()
    {
        if (!this.isReady) return;
        this.Summon();
    }

    

    protected virtual Transform Summon()
    {
        Transform spawPos = this.Abilities.AbilityObjectCtrl.SpawnPoints.GetRandomPoint();
        Transform prefab = this.spawner.GetPrefabRandom();  
        Transform newMinion = this.spawner.Spawn(prefab, spawPos.position, spawPos.rotation);
        newMinion.gameObject.SetActive(true);
        this.Active();
        return newMinion;
        
    }
}
