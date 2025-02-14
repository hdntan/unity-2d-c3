using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : MainMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model  => model; 

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn => junkDespawn;


    [SerializeField] protected JunkSO junkSo;
    public JunkSO JunkSO => junkSo; 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();   
        this.LoadJunkDespawn();
        this.LoadJunkSO();
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

    protected virtual void LoadJunkSO()
    {
        if (this.junkSo != null) return;
        string resPath = "Junk/" + transform.name;
        this.junkSo = Resources.Load<JunkSO>(resPath);
        Debug.Log(transform.name + " :LoadJunkSO" + resPath, gameObject);

    }
}
