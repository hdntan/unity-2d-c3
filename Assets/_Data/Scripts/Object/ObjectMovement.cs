using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] public Vector3 targetPosition; 
    [SerializeField] public float moveSpeed = 0.01f;
    [SerializeField] public float roteSpeed = 0.5f;

    [SerializeField] public float distance = 1f;
    [SerializeField] public float minDistance = 1f;



    protected virtual void FixedUpdate()
    {    

       this.LookAtTarget();
       this.Moving();
       
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

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.position, this.targetPosition);
        if (this.distance < this.minDistance) return;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPosition, this.moveSpeed * Time.deltaTime);
        transform.parent.position = newPos;
    }
}
 