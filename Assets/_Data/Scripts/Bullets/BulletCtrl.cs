using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MainMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get { return damageSender; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + " :LoadDamageSender", gameObject);
    }
}
