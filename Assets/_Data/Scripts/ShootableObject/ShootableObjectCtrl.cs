using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : MainMonoBehaviour
{

    [Header("Shootable Object ctrl")]
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;


    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;

    [SerializeField] protected ObjectShooting objectShooting;
    public ObjectShooting ObjectShooting => objectShooting;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadShootableObjectSO();
        this.LoadObjectShooting();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + " :LoadModel", gameObject);
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + " :LoadDespawn", gameObject);

    }

    protected virtual void LoadShootableObjectSO()
    {
        if (this.shootableObject != null) return;
        string resPath = "ShootableObject/" + this.GetObjTypeString() + "/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.Log(transform.name + " :LoadJunkSO" + resPath, gameObject);

    }

    protected virtual void LoadObjectShooting()
    {
        if (this.objectShooting != null) return;
        this.objectShooting = transform.GetComponentInChildren<ObjectShooting>();
        Debug.Log(transform.name + " :LoadObjectShooting", gameObject);

    }


    protected abstract string GetObjTypeString();
  
}
