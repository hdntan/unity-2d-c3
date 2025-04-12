using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance  => instance; 

    [SerializeField] protected float gameDropRate = 1f;



    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.instance != null) Debug.LogError("Only 1 InputManager allow to exits");
        ItemDropSpawner.instance = this;
    }


    public virtual List<ItemDropRate> DropItems(List<ItemDropRate> items)
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();

        float rate, itemRate;
        int itemDropMore;
        foreach (ItemDropRate item in items)
        {
            rate = Random.Range(0, 1f);
            itemRate = item.dropRate/100000f * this.GetGameDropRate();
            itemDropMore = Mathf.FloorToInt(itemRate);
            if (itemDropMore > 0) 
            {
                itemRate -= itemDropMore;
                for (int i = 0; i < itemDropMore; i++) 
                {
                    droppedItems.Add(item); 
                }
            }

            Debug.Log(item.ItemSO.itemName + "===Rate===" + itemRate + "/" + rate);
            Debug.Log("itemRate: " + itemRate);

            Debug.Log("itemDropMore: " + itemDropMore);


            if (rate <= itemRate) 
            {
                Debug.Log("==========Drop===========");
                droppedItems.Add(item);
            }
        }

        return droppedItems;
    }

    protected virtual float GetGameDropRate()
    {
        float dropRateFromItem = 0f;

        return this.gameDropRate + dropRateFromItem; 
    
    }

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList, Vector3 pos, Quaternion rota)
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();
        if (dropList.Count < 1) return droppedItems;

        droppedItems = this.DropItems(dropList);
        foreach (ItemDropRate item in droppedItems)
        {
            ItemCode itemDropName = item.ItemSO.itemCode;
            Transform itemDrop = this.Spawn(itemDropName.ToString(), pos, rota);
            if (itemDrop == null) continue;
            itemDrop.gameObject.SetActive(true);
        }


        return droppedItems;

    }

    public virtual Transform DropFromInventory(ItemInventory itemInventory, Vector3 pos, Quaternion rota)
    {
        ItemCode itemDropName = itemInventory.itemProfileSO.itemCode;
        Transform itemDrop = this.Spawn(itemDropName.ToString(), pos, rota);
        if (itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);
        ItemDropCtrl itemDropCtrl = itemDrop.GetComponent<ItemDropCtrl>();  
        itemDropCtrl.SetItemInventory(itemInventory);
        return itemDrop;

    }
}
