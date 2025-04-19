using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShipHp : BaseTxt
{
   protected virtual void FixedUpdate()
    {
        this.UpdateHp();
    }

    protected virtual void UpdateHp()
    {
        string hp = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HP.ToString();
        string hpMax = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HPMax.ToString();

        this.txt.SetText(hp +"/" + hpMax); 
    }
}
