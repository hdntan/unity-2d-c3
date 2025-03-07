using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemInventory 
{
    public ItemProfileSO itemProfileSO;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public virtual ItemInventory Clone()
    {
        ItemInventory item = new ItemInventory();
        item.itemProfileSO = this.itemProfileSO;
        item.itemCount = this.itemCount;
        item.upgradeLevel = this.upgradeLevel;
        item.maxStack = this.itemProfileSO.defaultMaxStack;

        return item;
    }
}
