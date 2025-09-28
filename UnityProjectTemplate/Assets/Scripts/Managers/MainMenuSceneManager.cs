using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneManager : Manager {
    public delegate void MainMenuSceneLoadedDelegate(MainMenuSceneManager mainMenuSceneManager);
    public static event MainMenuSceneLoadedDelegate mainMenuSceneLoadedEvent;

    [SerializeField] private MainMenuCanvas mainMenuCanvas;

    void Start() {
        mainMenuSceneLoadedEvent.Invoke(this);
    }

    public override void Setup(AppManager appManager) {
        base.Setup(appManager);
        print("MainMenuSceneManager Setup");
        appManager.RegisterMainMenuSceneManager(this);
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