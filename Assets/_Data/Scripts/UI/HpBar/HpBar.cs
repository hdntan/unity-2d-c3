using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MainMonoBehaviour
{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected SliderHp sliderHp;

    protected virtual void FixedUpdate()
    {
        this.ShowHP();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
    }

 

    protected virtual void LoadSliderHP()
    {
        if (this.sliderHp != null) return;
        this.sliderHp = GetComponentInChildren<SliderHp>();
        Debug.LogWarning(transform.name + " LoadSliderHP", gameObject);
    }

    protected virtual void SetShootableObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }

    protected virtual void ShowHP()
    {
        float hp = this.shootableObjectCtrl.DamageReceiver.HP;
        float hpMax = this.shootableObjectCtrl.DamageReceiver.HPMax;

        this.sliderHp.SetCurrentHp(hp);
        this.sliderHp.SetMaxHp(hpMax);  

    }


}
