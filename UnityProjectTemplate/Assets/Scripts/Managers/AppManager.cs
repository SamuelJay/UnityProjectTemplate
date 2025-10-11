using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : Manager, IApp {

    private void OnEnable() {
        Services.Register<IApp>(this);
        Services.Register<IEvents>(GetComponentInChildren<EventManager>() ?? gameObject.AddComponent<EventManager>());
        Services.Register<IScenes>(GetComponentInChildren<SceneLoadingManager>() ?? gameObject.AddComponent<SceneLoadingManager>());
        Setup();
    }

    private void Setup() {
        

        DontDestroyOnLoad(this);
        
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }


    private void OnDestroy() {
       
    }
}
