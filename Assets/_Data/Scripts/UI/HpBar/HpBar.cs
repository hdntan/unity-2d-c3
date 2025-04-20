using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MainMonoBehaviour
{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected SliderHp sliderHp;
    [SerializeField] protected FollowTarget followTarget;


    protected virtual void FixedUpdate()
    {
        this.HpShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
        this.LoadFollowTarget();
    }

 

    protected virtual void LoadSliderHP()
    {
        if (this.sliderHp != null) return;
        this.sliderHp = transform.GetComponentInChildren<SliderHp>();
        Debug.LogWarning(transform.name + " LoadSliderHP", gameObject);
    }

    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name + " LoadFollowTarget", gameObject);
    }

    public virtual void SetShootableObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }

    protected virtual void HpShowing()
    {
        if (this.shootableObjectCtrl == null) return;
        float hp = this.shootableObjectCtrl.DamageReceiver.HP;
        float hpMax = this.shootableObjectCtrl.DamageReceiver.HPMax;

        this.sliderHp.SetCurrentHp(hp);
        this.sliderHp.SetMaxHp(hpMax);  

    }

    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }


}
