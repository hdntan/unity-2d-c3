using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : MainMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model  => model; 

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn => junkDespawn;


    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject; 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();   
        this.LoadJunkDespawn();
        this.LoadShootableObjectSO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + " :LoadModel", gameObject);
    }

    protected virtual void LoadJunkDespawn()
    {
        if(this.junkDespawn != null) return;
        this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + " :LoadJunkDespawn", gameObject);

    }

    protected virtual void LoadShootableObjectSO()
    {
        if (this.shootableObject != null) return;
        string resPath = "ShootableObject/Junk/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.Log(transform.name + " :LoadJunkSO" + resPath, gameObject);

    }
}
