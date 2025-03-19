using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAppearWithoutShoot : ShootableObjectAbstract, IObjectAppearObverser
{
    [Header("Object Appear Without Shoot")]
    [SerializeField] protected ObjectAppearing objectAppearing;
    public ObjectAppearing ObjectAppearing => objectAppearing;

    protected override void OnEnable() 
    {
        base.OnEnable();
        this.RegisterAppearObserver();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectAppearing();

    }

    protected virtual void LoadObjectAppearing()
    {
        if (this.objectAppearing != null) return;
        this.objectAppearing = transform.GetComponent<ObjectAppearing>();
        Debug.Log(transform.name + " :LoadObjectAppearing", gameObject);
    }
    protected virtual void RegisterAppearObserver()
    {
        this.objectAppearing.AddObserver(this);
    }

    public void OnAppearedStart()
    {
        this.shootableObjectCtrl.ObjectShooting.gameObject.SetActive(false);
    }
    public void OnAppearedFinish()
    {
        this.shootableObjectCtrl.ObjectShooting.gameObject.SetActive(true);

    }
}
