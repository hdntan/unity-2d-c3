using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MainMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance { get { return instance; } }

    [SerializeField] protected Camera mainCamera;

    public Camera MainCamera { get { return mainCamera; } }

    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null) Debug.LogError("Only 1 InputManager allow to exits");
        GameCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMainCamera();
    }

    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera = null) return;
        this.mainCamera = Transform.FindObjectOfType<Camera>();
        Debug.Log(transform.name + " :LoadMainCamera", gameObject);

    }

}
