using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MainMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items => items;


    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.CopperSword,1);
        this.AddItem(ItemCode.IronOre, 12);
        this.AddItem(ItemCode.GoldOre, 5);


    }

    //public virtual bool AddItem(ItemCode itemCode, int addCount)
    //{
    //    ItemInventory itemInventory = this.GetItemByCode(itemCode);

    //    int newCount = itemInventory.itemCount + addCount;
    //    if (newCount > itemInventory.maxStack) return false;

    //    itemInventory.itemCount = newCount;  
    //    return true;
    //}

    //public virtual bool DeductItem(ItemCode itemCode, int deductCount)
    //{
    //    ItemInventory itemInventory = this.GetItemByCode(itemCode);

    //    int newCount = itemInventory.itemCount - deductCount;
    //    if (newCount < 0) return false;
    //    itemInventory.itemCount = newCount; 
    //    return true;
    //}
    //public virtual bool CheckDeductItem(ItemCode itemCode, int deductCount)
    //{
    //    ItemInventory itemInventory = this.GetItemByCode(itemCode);

    //    int newCount = itemInventory.itemCount - deductCount;
    //    if (newCount < 0) return false;
    //    return true; 
    //}

    //protected virtual ItemInventory GetItemByCode(ItemCode itemCode)
    //{
    //   ItemInventory itemInventory = this.items.Find((item) => item.itemProfileSO.itemCode == itemCode);
    //    if (itemInventory == null) itemInventory = this.AdddEmptyItemProfile(itemCode);
    //    return itemInventory;
    //}

    //protected virtual ItemInventory AdddEmptyItemProfile(ItemCode itemCode)
    //{
    //    var itemProfiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
    //    foreach (ItemProfileSO profile in itemProfiles) 
    //    {
    //        if (profile.itemCode != itemCode) continue;
    //        ItemInventory itemInventory = new ItemInventory
    //        {
    //            itemProfileSO = profile,
    //            maxStack = profile.defaultMaxStack, 
    //        };
    //        this.items.Add(itemInventory);
    //        return itemInventory;
    //    }
    //    return null;
    //}

    public virtual bool AddItem(ItemInventory itemInventory)
    {
        int addCount = itemInventory.itemCount;
        ItemProfileSO itemProfile = itemInventory.itemProfileSO;
        ItemCode itemCode = itemProfile.itemCode; 
        ItemType itemType = itemProfile.itemType;

        if (itemType == ItemType.Equiment) return this.AddEquiment(itemInventory);
        return this.AddItem(itemCode, addCount);
        
    }

    public virtual bool AddEquiment(ItemInventory itemPicked)
    {
        if (this.IsInventoryFull()) return false;
        ItemInventory item = itemPicked.Clone();
        this.items.Add(item);  
        return true; 
    }
    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;
        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode);
            if (itemExist == null)
            {
                if(this.IsInventoryFull()) return false;
                itemExist = this.CreateEmptyItem(itemProfile);
                this.items.Add(itemExist);
            }

            newCount = itemExist.itemCount  + addRemain;
            itemMaxStack = this.GetMaxStack(itemExist);
            if(newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }

            itemExist.itemCount = newCount;
            if (addRemain < 1) break;
        }
        return true;
    }


    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        
        int deduct;
        ItemInventory itemInventory;
        for (int i = this.items.Count - 1; i >= 0; i--)
        {
            if (deductCount < 0) break;
            itemInventory = this.items[i];
            if (itemInventory.itemProfileSO.itemCode != itemCode) continue;
            if (deductCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
                deductCount -= itemInventory.itemCount;
            }
            else
            {
                deduct = deductCount;
                deductCount = 0;
            }
            itemInventory.itemCount -= deduct;
        }
        this.ClearEmptySlot();
    }
    protected virtual bool IsInventoryFull()
    {
        if (this.items.Count >= this.maxSlot) return true;
        return false;
    }

    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var itemProfiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in itemProfiles)
        {
            if (profile.itemCode != itemCode) continue;     
            return profile;
        }
        return null;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode) 
    { 
        foreach(ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfileSO.itemCode != itemCode) continue; 
            if (this.IsFullStack(itemInventory)) continue;
            return itemInventory;

        }
       return null;
    }

    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if(itemInventory == null) return true;

        return (itemInventory.itemCount >= this.GetMaxStack(itemInventory));
     
    }

    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;

        return itemInventory.maxStack; 
    } 

    protected virtual ItemInventory CreateEmptyItem(ItemProfileSO itemProfileSO)
    {
        ItemInventory itemInventory = new ItemInventory{
            itemProfileSO = itemProfileSO,
            maxStack = itemProfileSO.defaultMaxStack,
        };
        return itemInventory;
    }

    public virtual bool ItemCheck(ItemCode itemCode, int itemCount)
    {
        int totalCount = this.ItemTotalCount(itemCode);
       
        return totalCount >= itemCount;
    }

    public virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0; 
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfileSO.itemCode != itemCode) continue;
            totalCount += itemInventory.itemCount;

        }
        return totalCount;
    }

    protected virtual void ClearEmptySlot()
    {
        ItemInventory itemInventory;
        for (int i = 0; i < this.items.Count; i++)
        {
            itemInventory = this.items[i];
            if(itemInventory.itemCount == 0) this.items.RemoveAt(i);
        }
    }
}


