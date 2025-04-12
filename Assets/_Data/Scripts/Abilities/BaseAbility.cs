using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : MainMonoBehaviour
{
    [Header("Base Ability")]
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isReady = false;

    [SerializeField] protected Abilities abilities;
    public Abilities Abilities => abilities;


    protected virtual void FixedUpdate()
    {
        this.Timming();
    }

    protected virtual void Update()
    {

    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilities();
    }

    protected virtual void LoadAbilities()
    {
        if (this.abilities != null) return;
        this.abilities = transform.parent.GetComponent<Abilities>();
        Debug.Log(transform.name + " :LoadAbilities", gameObject);
    }

    protected virtual void Timming()
    {
        if (this.isReady) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.isReady = true;    

    }

    protected virtual void Active()
    {
        this.isReady = false;
        this.timer = 0f;
    }



}
