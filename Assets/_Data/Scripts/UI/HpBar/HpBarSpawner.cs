using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarSpawner : Spawner
{
    private static HpBarSpawner instance;
    public static HpBarSpawner Instance { get => instance; }

    public static string HPBar = "HPBar";



    protected override void Awake()
    {
        base.Awake();
        if (HpBarSpawner.instance != null) Debug.LogError("Only 1 HpBarSpawner allow to exits");
        HpBarSpawner.instance = this;
    }
}
