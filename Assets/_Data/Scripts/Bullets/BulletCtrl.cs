using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MainMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + " :LoadDamageSender", gameObject);
    }

    protected virtual void LoadBulletDespawn()
    {
        if(this.bulletDespawn != null) return;
        this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + " :LoadBulletDespawn", gameObject);

    }

    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
