using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : Manager {
    public delegate void MainMenuSceneLoadedDelegate(MainMenuManager mainMenuManager);
    public static event MainMenuSceneLoadedDelegate mainMenuSceneLoadedEvent;

    [SerializeField] private MainMenuCanvas mainMenuCanvas;

    void Start() {
        mainMenuSceneLoadedEvent.Invoke(this);
    }

    public override void Setup(AppManager appManager) {
        base.Setup(appManager);
        print("MainMenuSceneManager Setup");
        appManager.RegisterMainMenuManager(this);
        uiManager.RegisterMainMenuCanvas(mainMenuCanvas);
        StartListeningToEvent<StartButtonPressedEvent>(OnStartButtonPressedEvent);
    }
    private void OnDestroy() {
        StopListeningToEvent<StartButtonPressedEvent>(OnStartButtonPressedEvent);
    }

    private void OnStartButtonPressedEvent(object sender, EventArgs data) {
        sceneLoadingManager.LoadScene("Game", LoadSceneMode.Single);
    }

}