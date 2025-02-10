using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MainMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void LoadTarget()
    {

    }

    protected virtual void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, this.target.position, speed * Time.fixedDeltaTime);
    }
}
