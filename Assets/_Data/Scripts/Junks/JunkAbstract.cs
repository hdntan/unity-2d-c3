using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : MainMonoBehaviour
{
    [SerializeField] protected JunkCtrl ctrl;
    public JunkCtrl Ctrl { get => ctrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + " :LoadJunkCtrl", gameObject);
    }
}
