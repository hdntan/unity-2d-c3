using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance { get => instance; }



    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.instance != null) Debug.LogError("Only 1 InputManager allow to exits");
        ItemDropSpawner.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rota)
    {
        ItemCode itemDropName = dropList[0].ItemSO.itemCode;
        Transform itemDrop = this.Spawn(itemDropName.ToString(), pos, rota);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);

    }
}
