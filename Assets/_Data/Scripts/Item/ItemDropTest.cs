using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropTest : MainMonoBehaviour
{
    public JunkCtrl junkCtrl;

    protected override void Start()
    {
        base.Start();
      InvokeRepeating(nameof(this.Dropping),2,0.5f);
    }

    protected virtual void Dropping()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRota = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObject.dropList, dropPos, dropRota);
    }
}
