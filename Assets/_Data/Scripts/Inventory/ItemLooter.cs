using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class ItemLooter : InventoryAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigidBody;



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollier();
        this.LoadRigidBody();
    }

    protected virtual void LoadSphereCollier()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.6f;

        Debug.LogWarning(transform.name + " :LoadCollider", gameObject);
    }

    protected virtual void LoadRigidBody()
    {
        if (this.rigidBody != null) return;
        this.rigidBody = transform.GetComponent<Rigidbody>();
        this.rigidBody.useGravity = false;
        this.rigidBody.isKinematic = true;

        Debug.LogWarning(transform.name + " :LoadRigidBody", gameObject);
    }




    protected virtual void OnTriggerEnter(Collider collider)
    {
       
        ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

       
        ItemInventory itemInventory = itemPickupable.ItemDropCtrl.ItemInventory;
        if (this.inventory.AddItem(itemInventory)) {
            itemPickupable.Picked();
        }

    }

 
}
