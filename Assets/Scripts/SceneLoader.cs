using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
{
   
    [SerializeField]
    private List<SceneEntity> scenes = new List<SceneEntity>(); // получает список сцен из инспектора

    // Update is called once per frame
    void Update()
    {
        foreach(SceneEntity scene in scenes)
        {
            scene.Load();
        }
    }
}
