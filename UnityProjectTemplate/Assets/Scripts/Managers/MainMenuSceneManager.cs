using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneManager : Manager {
    public delegate void MainMenuSceneLoadedDelegate(MainMenuSceneManager mainMenuSceneManager);
    public static event MainMenuSceneLoadedDelegate mainMenuSceneLoadedEvent;

    [SerializeField] private MainMenuCanvas mainMenuCanvas;
    
    private UIManager uiManager => appManager.uiManager;

    void Start() {
        mainMenuSceneLoadedEvent.Invoke(this);
    }

    public override void Setup(AppManager appManager) {
        base.Setup(appManager);
        print("MainMenuSceneManager Setup");
        appManager.RegisterMainMenuSceneManager(this);
        uiManager.RegisterMainMenuCanvas(mainMenuCanvas);
    }
}