using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAbstract : MainMonoBehaviour
{
    [SerializeField] protected BulletCtrl ctrl;
    public BulletCtrl BulletCtrl { get { return ctrl; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + " : LoadBulletCtrl", gameObject);

    }

}
