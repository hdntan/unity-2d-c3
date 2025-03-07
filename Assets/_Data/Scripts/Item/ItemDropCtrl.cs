using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropCtrl : MainMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected ItemDropDespawn itemDropDespawn;
    public ItemDropDespawn ItemDropDespawn => itemDropDespawn;


    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDropDespawn();
        this.LoadModel();   
        this.LoadItemInventory();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetItem();
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

    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory.Clone();
     

    }

    protected virtual void LoadItemInventory()
    {
        if(this.itemInventory.itemProfileSO != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfileSO = itemProfile;
        this.itemInventory.maxStack = itemProfile.defaultMaxStack;
        this.ResetItem();
        Debug.Log(transform.name + " :loadItemInventory", gameObject);
    }

    protected virtual void ResetItem()
    {
        this.itemInventory.itemCount = 1;
        this.itemInventory.upgradeLevel = 0;

    }
}
