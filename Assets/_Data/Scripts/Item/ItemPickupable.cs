using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : JunkAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;


    protected virtual void OnMouseDown()
    {
        PlayerCtrl.Instance.PlayerPickup.ItemPickup(this);
    }

    public static ItemCode String2ItemCode(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);

        }
        catch(ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.1f;
        Debug.Log(transform.name + " :LoadCollider", gameObject);
    }

    public virtual ItemCode GetItemCode()
    {
        return ItemPickupable.String2ItemCode(transform.parent.name);
    }

    public virtual void Picked()
    {
        this.ctrl.JunkDespawn.DespawnObject();
    }
}
