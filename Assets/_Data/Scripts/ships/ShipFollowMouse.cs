using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiptFollowMouse : ObjectMovement
{

    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
       
    }


    protected virtual void GetMousePosition()
    {
        this.targetPosition = InputManager.Instance.MousePosition;
        this.targetPosition.z = 0;
    }

}
