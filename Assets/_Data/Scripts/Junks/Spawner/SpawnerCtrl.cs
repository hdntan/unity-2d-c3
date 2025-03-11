using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : MainMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;

    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints => spawnPoints;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner(); 
        this.LoadSpawnPoint();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.GetComponent<Spawner>();
        Debug.Log(transform.name + " :LoadSpawner", gameObject);
    }


    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = Transform.FindObjectOfType<SpawnPoints>();
        Debug.Log(transform.name + " :LoadSpawnerPoints", gameObject);
    }

}
