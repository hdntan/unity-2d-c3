using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjModifyAbstract : MainMonoBehaviour
{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtrl(); 
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + " :LoadShootableObjectCtrl", gameObject);
    }
}
