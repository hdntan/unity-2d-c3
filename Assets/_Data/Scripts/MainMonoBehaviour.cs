using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void Start()
    {
        // override 
    }

    protected virtual void LoadComponents()
    {
        // override
    }

    protected virtual void ResetValue()
    {
        // override
    }

    protected virtual void OnEnable()
    {
        // override
    }
}
