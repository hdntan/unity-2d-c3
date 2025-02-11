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
        base.OnDead();
        this.ctrl.JunkDespawn.DespawnObject();  
    }
}
