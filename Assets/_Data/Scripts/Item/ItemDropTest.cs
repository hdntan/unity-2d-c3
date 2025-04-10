using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropTest : MainMonoBehaviour
{
    public JunkCtrl junkCtrl;
    [SerializeField] protected int dropCount;
    [SerializeField] protected List<ItemDropCount> itemDropCounts = new List<ItemDropCount>();

     protected override void Start()
    {
        base.Start();
      InvokeRepeating(nameof(this.Dropping),2,0.5f);
    }

    protected virtual void Dropping()
    {
        this.dropCount += 1;
        Vector3 dropPos = transform.position;
        Quaternion dropRota = transform.rotation;
        List<ItemDropRate> itemDrops  = ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObject.dropList, dropPos, dropRota);
        ItemDropCount itemDropCount;

        foreach(ItemDropRate itemDrop in itemDrops)
        {
            itemDropCount = this.itemDropCounts.Find(item => item.itemName == itemDrop.ItemSO.itemName);
            if(itemDropCount == null)
            {
                itemDropCount = new ItemDropCount();
                itemDropCount.itemName = itemDrop.ItemSO.itemName;  
                this.itemDropCounts.Add(itemDropCount);
            }

            itemDropCount.count += 1;
            itemDropCount.rate = (float)Math.Round((float)itemDropCount.count / this.dropCount, 2);
        }
    }
}

[Serializable]

public class ItemDropCount
{
    public string itemName;
    public int count;
    public float rate;
}
