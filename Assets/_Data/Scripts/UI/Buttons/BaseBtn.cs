using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseBtn : MainMonoBehaviour
{
    [Header("Base Button")]
    [SerializeField] protected Button btn;

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }


    protected virtual void LoadButton()
    {
        if (this.btn != null) return;
        this.btn = GetComponent<Button>();
        Debug.LogWarning(transform.name + " LoadButton", gameObject);
    }

    protected virtual void AddOnClickEvent()
    {
        this.btn.onClick.AddListener(this.OnClick);
    }

    protected abstract void OnClick();

}
