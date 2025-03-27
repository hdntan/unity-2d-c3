using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipModify : ObjModifyAbstract
{
    [Header("Mother Ship")]
    [SerializeField] protected float moveSpeed = 0.01f;
    [SerializeField] protected float rotSpeed = 0.1f;

    protected override void Start()
    {
        base.Start();
        this.ShipModify();
    }

    protected virtual void ShipModify()
    {
        this.shootableObjectCtrl.ObjectMovement.SetSpeed(this.moveSpeed);
        this.shootableObjectCtrl.ObjLookAtTarget.SetRotSeed(this.rotSpeed);

    }
}
