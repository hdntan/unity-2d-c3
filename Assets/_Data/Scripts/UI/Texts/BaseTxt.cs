using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseTxt : MainMonoBehaviour
{
    [Header("Base Button")]
    [SerializeField] protected TextMeshProUGUI txt;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }


    protected virtual void LoadText()
    {
        if (this.txt != null) return;
        this.txt = GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + " LoadText", gameObject);
    }
}
