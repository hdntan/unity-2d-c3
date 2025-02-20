using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MainMonoBehaviour
{
    private static DropManager instance;
    public static DropManager Instance { get => instance; }

    



    protected override void Awake()
    {
        base.Awake();
        if (DropManager.instance != null) Debug.LogError("Only 1 InputManager allow to exits");
        DropManager.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList)
    {
        Debug.Log(dropList[0].ItemSO.itemName);
    }
}

