using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
{
    [Serializable]
    private enum LoadMode { ByName, ByIndex }

    [Serializable]
    private class Scene
    {
        [SerializeField]
        private KeyCode key;
        [SerializeField]
        private LoadMode mode = LoadMode.ByName;
        [SerializeField]
        private string sceneName;
        [SerializeField]
        private short sceneIndex;

        private bool loaded;

        public KeyCode Key => key;

        public void Load()
        {
            if(loaded || !Input.GetKeyDown(key))
            {
                return;
            }

            AsyncOperation operation = mode == LoadMode.ByName ? SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive) : SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);

            if(operation == null)
            {
                Debug.LogError("Сцена не найдена");
            }
            
            loaded = true;
        }
    }

    [SerializeField]
    private List<Scene> scenes = new List<Scene>();

    // Update is called once per frame
    void Update()
    {
        foreach(Scene scene in scenes)
        {
            scene.Load();
        }
    }
}
