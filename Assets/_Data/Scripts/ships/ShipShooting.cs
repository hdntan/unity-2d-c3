using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipShooting : MainMonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDeley = 1f;
    [SerializeField] protected float shootTimer = 0f;




    protected virtual void Update()
    {
        this.IsShooting();
    }


    protected virtual void FixedUpdate()
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
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
        //Debug.Log("Shooting");
    }


    protected abstract bool IsShooting();
  
}
