using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : MainMonoBehaviour
{

    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + " :LoadPlayerPickup", gameObject);
    }
}
