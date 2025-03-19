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
        this.CreateImpactFx();   
        this.DestroyBullet();
    }






    protected virtual void DestroyBullet()
    {
        this.ctrl.BulletDespawn.DespawnObject();
    }

    protected virtual void CreateImpactFx()
    {
        string fxName = this.GetImpactName();
        Vector3 posHit = transform.position;
        Quaternion rotaHit = transform.rotation;
        Transform newImpactFx = FxSpawner.Instance.Spawn(fxName, posHit, rotaHit);
        newImpactFx.gameObject.SetActive(true);
    }

    protected virtual string GetImpactName()
    {
        return FxSpawner.impact1;
    }




}
