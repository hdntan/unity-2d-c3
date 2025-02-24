using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MainMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
        this.CreateImpactFx();
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
