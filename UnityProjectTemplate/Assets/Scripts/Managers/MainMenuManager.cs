using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : Manager {
    private SceneLoadingManager sceneLoadingManager => appManager.sceneLoadingManager;
    

    public override void Setup(AppManager appManager) {
        base.Setup(appManager);
        MainMenuSceneManager.mainMenuSceneLoadedEvent += OnMainMenuSceneLoadedEvent;
        StartListeningToEvent<StartButtonPressedEvent>(OnStartButtonPressedEvent);
    }

    private void OnMainMenuSceneLoadedEvent(MainMenuSceneManager mainMenuSceneManager) {
        mainMenuSceneManager.Setup(appManager);
    }

    private void OnStartButtonPressedEvent(object sender, EventArgs data) {
        sceneLoadingManager.LoadScene("Game", LoadSceneMode.Single);
    }

    private void OnDestroy() {
        StopListeningToEvent<StartButtonPressedEvent>(OnStartButtonPressedEvent);
    }
}
