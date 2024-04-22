using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager {
    private SceneLoadingManager sceneLoadingManager => appManager.sceneLoadingManager;

    public override void Setup(AppManager appManager) {
        base.Setup(appManager);
        GameSceneManager.gameSceneLoadedEvent += OnGameSceneLoadedEvent;
        StartListeningToEvent<ExitButtonPressedEvent>(OnExitButtonPressedEvent);
    }

    private void OnGameSceneLoadedEvent(GameSceneManager gameSceneManager) {
        gameSceneManager.Setup(appManager);
    }

    private void OnExitButtonPressedEvent(object sender, EventArgs data) {
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            TriggerEvent<ExitButtonPressedEvent>(new ExitButtonPressedEvent());
        }
    }
}
