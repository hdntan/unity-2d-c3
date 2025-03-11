using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowTarget : ShipMovement
{
    [SerializeField] protected Transform target;

    protected override void FixedUpdate()
    {
        this.GetTargerPosition();
        base.FixedUpdate();

    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

     
    protected virtual void GetTargerPosition()
    {
        this.targetPosition = this.target.position;
        this.targetPosition.z = 0;
    }

}
