using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : MainMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl ctrl;

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
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform ranPoint = this.ctrl.JunkSpawnPoints.GetRandomPoint();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform newObj = this.ctrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        newObj.gameObject.SetActive(true);

        Invoke(nameof(this.JunkSpawning), 1f);
    }
}
