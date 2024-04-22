using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : Manager
{
    public delegate void GameSceneLoadedDelegate(GameSceneManager gameSceneManager);
    public static event GameSceneLoadedDelegate gameSceneLoadedEvent;


    [SerializeField] private GameCanvas gameCanvas;

    private UIManager uiManager => appManager.uiManager;

    void Start() {
        gameSceneLoadedEvent.Invoke(this);
    }

    public override void Setup(AppManager appManager) {
        base.Setup(appManager);
        print("MainMenuSceneManager Setup");
        appManager.RegisterGameSceneManager(this);
        uiManager.RegisterGameCanvas(gameCanvas);
    }
}
