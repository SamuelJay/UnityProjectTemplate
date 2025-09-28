using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : Manager {
    public EventManager eventManagerInstance { get; private set; }
    public SceneLoadingManager sceneLoadingManagerInstance { get; private set; }
    public UIManager uiManagerInstance { get; private set; }
    public MainMenuSceneManager mainMenuSceneManager { get; private set; }
    public GameSceneManager gameSceneManager { get; private set; }

    [SerializeField] private EventManager eventManagerPrefab;
    [SerializeField] private SceneLoadingManager sceneLoadingManagerPrefab;
    [SerializeField] private UIManager uiManagerPrefab;

    private void Awake() {
        Setup(this);
    }

    public override void Setup(AppManager appManager) {
        base.Setup(appManager);
        eventManagerInstance = Instantiate(eventManagerPrefab);
        sceneLoadingManagerInstance = Instantiate(sceneLoadingManagerPrefab);
        uiManagerInstance = Instantiate(uiManagerPrefab);

        DontDestroyOnLoad(this);
        DontDestroyOnLoad(eventManagerInstance);
        DontDestroyOnLoad(sceneLoadingManagerInstance);
        DontDestroyOnLoad(uiManagerInstance);

        eventManagerInstance.Setup(this);
        sceneLoadingManagerInstance.Setup(this);
        uiManagerInstance.Setup(this);

        MainMenuSceneManager.mainMenuSceneLoadedEvent += OnMainMenuSceneLoadedEvent;
        GameSceneManager.gameSceneLoadedEvent += OnGameSceneLoadedEvent;
        sceneLoadingManagerInstance.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void OnDestroy() {
        MainMenuSceneManager.mainMenuSceneLoadedEvent -= OnMainMenuSceneLoadedEvent;
        GameSceneManager.gameSceneLoadedEvent -= OnGameSceneLoadedEvent;
    }

    public void RegisterMainMenuSceneManager(MainMenuSceneManager mainMenuSceneManager) {
        this.mainMenuSceneManager = mainMenuSceneManager;
    }

    private void OnMainMenuSceneLoadedEvent(MainMenuSceneManager mainMenuSceneManager) {
        mainMenuSceneManager.Setup(appManager);
    }

    public void RegisterGameSceneManager(GameSceneManager gameSceneManager) {
        this.gameSceneManager = gameSceneManager;
    }

    private void OnGameSceneLoadedEvent(GameSceneManager gameSceneManager) {
        gameSceneManager.Setup(appManager);
    }
}
