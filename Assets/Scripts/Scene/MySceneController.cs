using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public abstract class MySceneController : MonoBehaviour
{
    //[SerializeField] UI_Controller uiController;
    [SerializeField] Camera mainCamera;
    

    protected virtual void Awake()
    {
        if (SceneManager.GetSceneByName("SystemScene").isLoaded == true)
        {
            Debug.Log("Have SystemScene");
        }
        else
        {
            SceneManager.LoadSceneAsync((int)MySceneManager.SceneIndex.SystemScene, LoadSceneMode.Additive);
            Debug.Log("Load SystemScene");
 
        }

        //Debug.Log("DisACtive object");
        //gameObject.SetActive(false);

        //StartCoroutine(CheckIsActiveScene());
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        CallSystemScene();

        //if (uiController == null)
        //{
        //    uiController = FindAnyObjectByType<UI_Controller>();
        //}
        //else
        //{
        //    uiController.Init();
        //}


    }

    void CallSystemScene()
    {
        bool hasSystemScene = false;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == MySceneManager.SceneIndex.SystemScene.ToString())
            {
                hasSystemScene = true;
                Debug.Log("CallSystemScene Has SystemScene");
                break;
            }
        }

        if (!hasSystemScene)
        {
            Debug.Log("dont has System Scene");

            MySceneManager.Instance.LoadSystemSceneAsync(SceneTeamSceneCallback);
        }


        //Scene systemScene = SceneManager.GetSceneByName(MySceneManager.SceneIndex.SystemScene.ToString());
        //while (!systemScene.isLoaded)
        //{
        //    Debug.Log("Dont have System Scene");
        //}

    }

    void SceneTeamSceneCallback()
    {

    }


}
