using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MainMonoBehaviour
{
    [Header("Obj Movement")]
    [SerializeField] public Vector3 targetPosition; 
    [SerializeField] public float moveSpeed = 0.01f;
    [SerializeField] public float distance = 1f;
    [SerializeField] public float minDistance = 1f;
    [SerializeField] protected Vector3 drirection = Vector3.right;




    protected virtual void FixedUpdate()
    {    
       this.Moving();
    }

    public virtual void SetSpeed(float speed)
    {
        this.moveSpeed = speed;
    }

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.position, this.targetPosition);
        if (this.distance < this.minDistance) return;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPosition, this.moveSpeed);
        transform.parent.position = newPos;
    }
}
 