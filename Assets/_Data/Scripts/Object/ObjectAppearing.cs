using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAppearing : MainMonoBehaviour
{
    [Header("Object Appearing")]
    [SerializeField] protected bool isAppearing = false;
    [SerializeField] protected bool appeared = false;

    [SerializeField] protected List<IObjectAppearObverser> observers = new List<IObjectAppearObverser>();

    public bool IsAppearing => isAppearing;
    public bool Appeared => appeared;

    protected override void Start()
    {
        base.Start();
        this.OnAppearStart();
        
    }

    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }

    protected abstract void Appearing();


    public virtual void Appear()
    {
        this.appeared = true;
        this.isAppearing = false;
        this.OnAppearedFinish();    
    }

    public virtual void AddObserver(IObjectAppearObverser observer) 
    {
        this.observers.Add(observer);
    }

    protected virtual void OnAppearStart()
    {
        foreach (IObjectAppearObverser observer in this.observers)
        {
            observer.OnAppearedStart();
        }
    }

    protected virtual void OnAppearedFinish()
    {
        foreach (IObjectAppearObverser observer in this.observers)
        {
            observer.OnAppearedFinish();
        }
    }

}
