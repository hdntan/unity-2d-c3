using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : MainMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl ctrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected int randomLimit = 9;




    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawnerCtrl();
    }

    protected virtual void LoadJunkSpawnerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + " :LoadJunkSpawnerCtrl", gameObject);
    }

    protected override void Start()
    {
       
    }

    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform ranPoint = this.ctrl.JunkSpawnPoints.GetRandomPoint();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform newObj = this.ctrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        newObj.gameObject.SetActive(true);

       
    }

    protected virtual bool RandomReachLimit ()
    {
        int currentJunkCount = this.ctrl.JunkSpawner.SpawnCount;
        return currentJunkCount >= this.randomLimit;
      
    }
}
