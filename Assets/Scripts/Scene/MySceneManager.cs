using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class MySceneManager : Singleton<MySceneManager>
{
    //List<AsyncOperation> sceneLoadingList = new List<AsyncOperation>();

    //public Action SystemSceneCallback;
    public static Action<SceneIndex> OnSceneLoaded;

    public enum SceneIndex
    {
        SystemScene,
        LoadingScene,
        LoginScene,
        LobbyScene,
        StartScene,
        PickHeroScene,
        GamePlayScene,
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public void LoadScene(SceneIndex sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex.ToString());
    }

    public void LoadSystemSceneAsync(Action SystemSceneCallback)
    {
        //SceneManager.LoadSceneAsync(SceneIndex.SystemScene.ToString(), LoadSceneMode.Additive);
        StartCoroutine(LoadSystemScene(SystemSceneCallback));
    }

    public IEnumerator LoadSystemScene(Action systemSceneCallback)
    {
        AsyncOperation asyncOperation =
            SceneManager.LoadSceneAsync(SceneIndex.SystemScene.ToString(), LoadSceneMode.Additive); ;

        while (!asyncOperation.isDone)
        {
            yield return null;

        }

        Debug.Log("Active scene is: " + SceneManager.GetActiveScene().name);

        Scene targetScene = SceneManager.GetSceneByName(MySceneManager.SceneIndex.SystemScene.ToString());
        SceneManager.MoveGameObjectToScene(this.gameObject, targetScene);
        systemSceneCallback?.Invoke();

    }

    //Cai nay load scene target + them system scene
    public void LoadingSceneAsync(SceneIndex sceneIndex)
    {

        //SceneManager.LoadSceneAsync(sceneIndex.ToString(), LoadSceneMode.Additive);

        StartCoroutine(LoadingSceneAsyncCoroutine(sceneIndex));

    }

    public IEnumerator LoadingSceneAsyncCoroutine(SceneIndex sceneIndex)
    {
        //LoadNewScene
        Debug.Log("Load Scene " + sceneIndex.ToString());

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex.ToString(), LoadSceneMode.Additive);

        Debug.Log("Current Active scene is " + SceneManager.GetActiveScene().name);

        asyncOperation.allowSceneActivation = false;

        //Scene loadedScene = SceneManager.GetSceneByName(sceneIndex.ToString());

        ////Disable All Script 
        //if (!loadedScene.isLoaded)
        //{
        //    DisableAllScriptsInLoadedScene(loadedScene);
        //}

        //Don't let the Scene activate until you allow it to
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            //Debug.Log( "Loading progress: " + (asyncOperation.progress * 100) + "%");

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Wait to you press the space key to activate the Scene
                //if (Input.GetKeyDown(KeyCode.Space))
                //    //Activate the Scene
                //    asyncOperation.allowSceneActivation = true;

                //Just keep newScene and system scene
                KeepNewSceneAndSystemScene(sceneIndex);
                
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }

        //Active All Script again
        //if (asyncOperation.isDone)
        //{
        //    EnableAllScriptsInLoadedScene(loadedScene);
        //}

       
        //Change active scene
        if (sceneIndex != SceneIndex.SystemScene)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneIndex.ToString()));
        }

        //Debug.Log("Active scene is " + SceneManager.GetActiveScene().name);

        //Goi ve khi scene load xong
        OnSceneLoaded?.Invoke(sceneIndex);
        //SceneLoadedCallback();
       
    }

    public void UnLoadScene(SceneIndex sceneIndex)
    {
        //Debug.Log("Unload scene" + sceneIndex);

        SceneManager.UnloadSceneAsync(sceneIndex.ToString());

    }
    public void UnLoadScene(string sceneName)
    {
        //Debug.Log("Unload scene" + sceneName);
        SceneManager.UnloadSceneAsync(sceneName);

    }
   
    void KeepNewSceneAndSystemScene(SceneIndex sceneIndex)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene tmp = SceneManager.GetSceneAt(i);

            if ((tmp.name != SceneIndex.SystemScene.ToString()) && tmp.name != sceneIndex.ToString())
            {
                Debug.Log("Nhung Scene dang active Scene name : " + tmp.name);

                UnLoadScene(tmp.name);
            }
        }
    }

    void EnableAllScriptsInLoadedScene(Scene activeScene)
    {
        Debug.Log("Active back All Script");
        foreach (GameObject obj in activeScene.GetRootGameObjects())
        {
            MonoBehaviour[] scripts = obj.GetComponentsInChildren<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = true;
            }
        }
    }

    void DisableAllScriptsInLoadedScene(Scene loadedScene)
    {
        Debug.Log("disable all Scripts on loadedScene");

        foreach (GameObject obj in loadedScene.GetRootGameObjects())
        {
            MonoBehaviour[] scripts = obj.GetComponentsInChildren<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
        }
        
    }

    void SceneLoadedCallback()
    {
        //if (asyncOperation.isDone)
        //{
        //    Scene scene = SceneManager.GetSceneByName(sceneIndex.ToString());

        //    GameObject[] rootObjects = scene.GetRootGameObjects();

        //    foreach (GameObject rootObject in rootObjects)
        //    {
        //        var tmp = rootObject.GetComponent<SceneLoadListener>();

        //        if (tmp != null)
        //        {
        //            tmp.ActiveSceneController();
        //            break;
        //        }
        //    }
        //}
    }

    public void SwitchSceneAsync(SceneIndex sceneIndex)
    {
        //loadingSceen.SetActive(true);

        //StartCoroutine(LoadingProgress(sceneIndex));
        //SceneManager.UnloadSceneAsync((int)currentScene);

    }





}
