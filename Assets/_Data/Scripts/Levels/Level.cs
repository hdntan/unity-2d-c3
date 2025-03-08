using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MainMonoBehaviour 
{
    [SerializeField] protected int currentLevel = 0;
    [SerializeField] protected int maxLevel = 99;

    public int CurrentLevel => currentLevel;
    public int MaxLevel => maxLevel;

    protected virtual void LevelUp()
    {
        this.currentLevel += 1;
        this.LimitLevel();

    }
    
    protected virtual void SetLevel(int newLevel)
    {
        this.currentLevel = newLevel;
        this.LimitLevel();
    }

    protected virtual void LimitLevel()
    {
        if(this.currentLevel > this.maxLevel) this.currentLevel = this.maxLevel;
        if(this.currentLevel < 1) this.currentLevel = 1;
    }




}
