using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingByDistance : ObjectShooting
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float minDistance = 3f;

    protected virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected override bool IsShooting()
    {
        this.distance = Vector3.Distance(transform.position, target.position);
        this.isShooting = this.distance < minDistance;
        return this.isShooting;
     
    }
}
