using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] public Vector3 targetPosition; 
    [SerializeField] public float moveSpeed = 5f;

    void FixedUpdate()
    {    
       this.GetTargetPosition();
       this.LookAtTarget();
       this.Moving();
       
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MousePosition;
        this.targetPosition.z = 0;
    }

    protected virtual void LookAtTarget()
    {
      
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPosition, this.moveSpeed * Time.deltaTime);
        transform.parent.position = newPos;
    }
}
 