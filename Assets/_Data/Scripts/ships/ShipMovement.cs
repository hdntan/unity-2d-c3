using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] public Vector3 worldPostion; 
    [SerializeField] public float moveSpeed = 5f;

    void FixedUpdate()
    {
       
        if (Camera.main == null) return;
        this.worldPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.worldPostion.z = 0;
        Vector3 newPos = Vector3.Lerp(transform.position, this.worldPostion, this.moveSpeed * Time.deltaTime);
        transform.position = newPos;
    }
}
 