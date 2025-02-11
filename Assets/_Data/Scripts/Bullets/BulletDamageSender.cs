using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    
    protected virtual void LoadBulletCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + " :LoadBulletCtrl", gameObject);

    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyBullet();
    }
     
    protected virtual void DestroyBullet()
    {
        this.ctrl.BulletDespawn.DespawnObject();
    }




}
