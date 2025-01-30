using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected Transform bulletPrefab;


    private void FixedUpdate()
    {
        this.Shooting();   
    }

    protected virtual void Shooting()
    { 
        if (!this.isShooting) return;
        Vector3 spawnPos = transform.parent.position;
        Quaternion roatation = transform.parent.rotation;
        Instantiate(this.bulletPrefab, spawnPos,roatation);
        Debug.Log("Shooting");
    }
}
