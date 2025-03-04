using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryAbstract : MainMonoBehaviour
{
   
    [SerializeField] protected Inventory inventory;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.LogWarning(transform.name + " :LoadInventory", gameObject);
    }

}
