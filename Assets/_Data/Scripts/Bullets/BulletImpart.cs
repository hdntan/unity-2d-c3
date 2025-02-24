using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class BulletImpart : BulletAbstract
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected Rigidbody _rigidbody;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigibody();    
    }

    protected virtual void LoadCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = transform.GetComponent<CapsuleCollider>();
        this.capsuleCollider.isTrigger = true;
        this.capsuleCollider.radius = 0.05f;
        this.capsuleCollider.height = 0.4f;
        this.capsuleCollider.direction = 0;
        Debug.Log(transform.name + " :LoadCollider", gameObject);

    }

    protected virtual void  LoadRigibody()
    {
        if(this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + " :LoadRigibody", gameObject);

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
      
        if (other.transform.parent == this.ctrl.Shooter) return;
        this.ctrl.DamageSender.Send(other.transform);
       // this.CreateImpactFx(other);
    }

    //protected virtual void CreateImpactFx(Collider other)
    //{
    //    string fxName = this.GetImpactName();
    //    Vector3 posHit = transform.position;
    //    Quaternion rotaHit = transform.rotation;
    //    Transform newImpactFx = FxSpawner.Instance.Spawn(fxName, posHit, rotaHit);
    //    newImpactFx.gameObject.SetActive(true);
    //}

    //protected virtual string GetImpactName()
    //{
    //   return FxSpawner.impact1;
    //}
}
