using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [SerializeField] protected JunkCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + " :LoadJunkCtrl", gameObject);
    }

    protected override void OnDead()
    {

        this.OnDeadFx();
        this.ctrl.JunkDespawn.DespawnObject();
        //Drop Item
       DropManager.Instance.Drop(this.ctrl.JunkSO.dropList);
    }

    protected virtual void OnDeadFx()
    {
        string fxName = this.GetOnDeadFxName();
        Transform newFxOnDead = FxSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        newFxOnDead.gameObject.SetActive(true); 
    }

    protected virtual string GetOnDeadFxName()
    {
        return FxSpawner.smoke1;
    }

    public override void Reborn()
    {
        this.hpMax = this.ctrl.JunkSO.hpMax;
        base.Reborn();
    }
}

