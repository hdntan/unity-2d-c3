using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] public Vector3 worldPostion; 
    [SerializeField] public float moveSpeed = 5f;

    void FixedUpdate()
    {    
        this.worldPostion = InputManager.instance.mouseWorldPos;
        this.worldPostion.z = 0;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.worldPostion, this.moveSpeed * Time.deltaTime);
        transform.parent.position = newPos;
    }
}
 