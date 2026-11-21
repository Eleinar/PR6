using System;
using UnityEngine;
using UnityEngine.SceneManagement;



[Serializable]
public class SceneEntity
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

    public void Load() // по нажатию на кнопку загружает сцену 
    {
        if (loaded)
        {
            return;
        }
        if(Input.GetKeyDown(key))
        {
            AsyncOperation operation = mode == LoadMode.ByName ? SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive) : 
                SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);

            if (operation == null)
            {
                Debug.LogError("—цена не найдена");
            }

            loaded = true;
        }

        
    }
}