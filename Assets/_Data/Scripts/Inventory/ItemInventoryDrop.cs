using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemInventoryDrop : InventoryAbstract
{
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 5);
    }

    protected virtual void Test()
    {
        Vector3 pos = transform.position;
        pos.x += 1;
        this.DropItemIndex(0,pos, transform.rotation);
    }

    protected virtual void DropItemIndex(int indexItem, Vector3 pos, Quaternion rot)
    {

        ItemInventory itemInventory = this.inventory.Items[indexItem];
        
        ItemDropSpawner.Instance.Drop(itemInventory, pos, rot);
        this.inventory.Items.Remove(itemInventory);

    }
}
