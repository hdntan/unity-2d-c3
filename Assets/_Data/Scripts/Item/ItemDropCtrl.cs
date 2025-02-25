using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropCtrl : MainMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected ItemDropDespawn itemDropDespawn;
    public ItemDropDespawn ItemDropDespawn => itemDropDespawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDropDespawn();
        this.LoadModel();   
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + " :LoadModel", gameObject);
    }

    protected virtual void LoadItemDropDespawn()
    {
        if (this.itemDropDespawn != null) return;
        this.itemDropDespawn = transform.GetComponentInChildren<ItemDropDespawn>();
        Debug.Log(transform.name + " :LoadItemDropDespawn", gameObject);
    }
}
