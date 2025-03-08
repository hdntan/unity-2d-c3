using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : MainMonoBehaviour
{
    [SerializeField] protected string nameScene = "GalaxyDemo";
   protected virtual void OnMouseDown()
    {
        Debug.Log("WormHole Click");
        this.LoadSceneGalaxy(); 
    }

    protected virtual void LoadSceneGalaxy()
    {
        SceneManager.LoadScene(this.nameScene);
    }
}
