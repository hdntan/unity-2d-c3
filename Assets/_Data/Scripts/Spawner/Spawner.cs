using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Spawner : MainMonoBehaviour
{
  
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected Transform holder;


    [SerializeField] protected int spawnCount = 0;
    public int SpawnCount { get => spawnCount; }



    protected override void LoadComponents()
    {   
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
   
        Transform prefabObj = transform.Find("Prefabs");
        foreach(Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
        Debug.Log(transform.name + ":LoadPrefabs", gameObject);
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach(Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion roatation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        
        if(prefab == null)
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }   

        
        return this.Spawn(prefab,spawnPos,roatation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion roatation)
    {
       
        Transform newPrefab = this.GetObjFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, roatation);
        newPrefab.parent = this.holder;
        this.spawnCount++;
        return newPrefab;
    }

    protected virtual Transform GetObjFromPool(Transform prefab)
    {
        foreach(Transform obj in this.poolObjs)
        {
            if(obj.name == prefab.name)
            {
                this.poolObjs.Remove(obj);   
                 return obj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;   
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnCount--;
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if(prefab.name == prefabName) return prefab;
        }
        return null;
    }

    public virtual Transform GetPrefabRandom()
    {
        int ran = Random.Range(0, this.prefabs.Count);
        return this.prefabs[ran];
    }

}
