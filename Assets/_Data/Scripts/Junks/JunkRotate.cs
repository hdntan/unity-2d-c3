using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float speed = 9f;

    protected virtual void FixedUpdate()
    {
        this.Rotating();
    }

    protected virtual void Rotating()
    {
        Vector3 elures = new Vector3(0,0,1);
        this.ctrl.Model.Rotate(elures * this.speed * Time.fixedDeltaTime);
    }
}
