using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : Manager
{
    public delegate void GameSceneLoadedDelegate(GameSceneManager gameSceneManager);
    public static event GameSceneLoadedDelegate gameSceneLoadedEvent;


    [SerializeField] private GameCanvas gameCanvas;

   


    void Start() {
        gameSceneLoadedEvent.Invoke(this);
    }

    public override void Setup(AppManager appManager) {
        base.Setup(appManager);
        print("MainMenuSceneManager Setup");
        appManager.RegisterGameSceneManager(this);
        uiManager.RegisterGameCanvas(gameCanvas);
        StartListeningToEvent<ExitButtonPressedEvent>(OnExitButtonPressedEvent);
    }

    private void OnDestroy() {
        StopListeningToEvent<ExitButtonPressedEvent>(OnExitButtonPressedEvent);
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            TriggerEvent<ExitButtonPressedEvent>(new ExitButtonPressedEvent());
        }
    }

    private void OnExitButtonPressedEvent(object sender, EventArgs data) {
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
