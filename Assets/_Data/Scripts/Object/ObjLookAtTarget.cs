using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtTarget : MainMonoBehaviour
{
    [SerializeField] public Vector3 targetPosition;
    [SerializeField] public float roteSpeed = 3f;



    protected virtual void FixedUpdate()
    {

        this.LookAtTarget();

    }

    public virtual void SetRotSeed(float seed)
    {
        this.roteSpeed = seed;
    }

    protected virtual void LookAtTarget()
    {

        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();

        float timeSpeed = this.roteSpeed * Time.fixedDeltaTime;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);
        transform.parent.rotation = currentEuler;
    }

  
}
