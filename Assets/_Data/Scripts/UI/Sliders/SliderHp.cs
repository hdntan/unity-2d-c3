using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHp : BaseSlider
{
    [SerializeField] protected float maxHp = 100;
    [SerializeField] protected float currentHp = 90;

    protected override void FixedUpdate()
    {
        this.HpShowing();
    }

    protected virtual void HpShowing()
    {
        float percentHp = this.currentHp / this.maxHp;
        this.slider.value = percentHp;  
    }

    protected override void OnChange(float newValue)
    {
      Debug.Log("new value" + newValue);
    }

    public virtual void SetMaxHp(float hp)
    {
        this.maxHp = hp;    
    }

    public virtual void SetCurrentHp(float hp)
    {
        this.currentHp = hp;
    }
}


