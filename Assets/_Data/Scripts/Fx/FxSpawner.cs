using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxSpawner : Spawner
{
    private static FxSpawner instance;
    public static FxSpawner Instance => instance; 

    public static string smoke1 = "Smoke_1";
    public static string impact1 = "Impact_1";




    protected override void Awake()
    {
        base.Awake();
        if (FxSpawner.instance != null) Debug.LogError("Only 1 InputManager allow to exits");
        FxSpawner.instance = this;
    }
}
