using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected Transform bullet;


    private void FixedUpdate()
    {
        this.Shooting();   
    }

    protected virtual void Shooting()
    {
        if (!this.isShooting) return;
        Instantiate(this.bullet);
        Debug.Log("Shooting");
    }
}
