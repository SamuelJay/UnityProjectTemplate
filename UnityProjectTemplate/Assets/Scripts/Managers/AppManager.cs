using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : Manager, IApp {

    private void OnEnable() {
        Services.RegisterApp<IApp>(this);
        Services.RegisterApp<IEvents>(GetComponentInChildren<EventManager>() ?? gameObject.AddComponent<EventManager>());
        Services.RegisterApp<IScenes>(GetComponentInChildren<SceneLoadingManager>() ?? gameObject.AddComponent<SceneLoadingManager>());
        Setup();         
    }

    private void Setup() {
        

        DontDestroyOnLoad(this);
        
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }


    private void OnDestroy() {
        Services.UnregisterApp<IApp>(this);
    }
}
