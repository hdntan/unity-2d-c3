using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : MainMonoBehaviour
{
    [SerializeField] protected JunkCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + " :LoadJunkCtrl", gameObject);
    }

    protected override void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Transform newObj = this.ctrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        newObj.gameObject.SetActive(true);

        Invoke(nameof(this.JunkSpawning), 1f);
    }
}
