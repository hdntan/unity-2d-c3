using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjDamageReceiver : DamageReceiver
{
   

    [SerializeField] protected ShootableObjectCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + " :LoadShootableObjectCtrl", gameObject);
    }

    protected override void OnDead()
    {

        this.OnDeadFx();
        this.OnDeadDrop();
        this.ctrl.Despawn.DespawnObject();
        //Drop Item
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRota = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.ctrl.ShootableObject.dropList, dropPos, dropRota);

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
        this.hpMax = this.ctrl.ShootableObject.hpMax;
        base.Reborn();
    }
}
