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
        this.DropItemIndex(0);
    }

    protected virtual void DropItemIndex(int indexItem)
    {
        Debug.Log(indexItem);
        ItemInventory itemInventory = this.inventory.Items[indexItem];
        Debug.Log(itemInventory.itemProfileSO.itemCode);
        Debug.Log(itemInventory.upgradeLevel);
        Vector3 pos = transform.position;
        pos.x += 1;

        ItemDropSpawner.Instance.Drop(itemInventory, pos, transform.rotation);
    }
}
