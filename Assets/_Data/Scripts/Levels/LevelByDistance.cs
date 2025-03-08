using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByDistance : Level
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected float distancePerLevel = 10f;

    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }

    protected virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected virtual void Leveling()
    {
       

        if (this.target == null) return;
        this.distance = Vector3.Distance(transform.position, this.target.position);
  
        int newLevel = this.GetLevelByDistance();
        this.SetLevel(newLevel);    
    }

    protected virtual int GetLevelByDistance()
    {
        return Mathf.FloorToInt(this.distance / this.distancePerLevel) + 1;
    }


}
