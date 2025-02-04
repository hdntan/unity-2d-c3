using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDeley = 1f;
    [SerializeField] protected float shootTimer = 0f;




    void Update()
    {
        this.IsShooting();
    }


    private void FixedUpdate()
    {
        this.Shooting();

    }


    protected virtual void Shooting() 
    { 
        if (!this.isShooting) return;
        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDeley) return;
        this.shootTimer = 0;
        
        Vector3 spawnPos = transform.parent.position; 
        Quaternion roatation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, roatation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        Debug.Log("Shooting");
    }


    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
