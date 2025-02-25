using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemDropAbstract : MainMonoBehaviour
{
    [Header("ItemDropAbstract")]
    [SerializeField] protected ItemDropCtrl itemDropCtrl;
    public ItemDropCtrl ItemDropCtrl => itemDropCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDropCtrl();
    }

    protected virtual void LoadItemDropCtrl()
    {
        if (this.itemDropCtrl != null) return;
        this.itemDropCtrl = transform.parent.GetComponent<ItemDropCtrl>();
        Debug.Log(transform.name + " :LoadItemDropCtrl", gameObject);
    }
}
