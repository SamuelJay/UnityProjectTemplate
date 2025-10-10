using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : Manager {
    public EventManager eventManagerInstance { get; private set; }
    public SceneLoadingManager sceneLoadingManagerInstance { get; private set; }
    public UIManager uiManagerInstance { get; private set; }
    public MainMenuManager mainMenuManager { get; private set; }
    public GameManager gameManager { get; private set; }

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

        MainMenuManager.mainMenuSceneLoadedEvent += OnMainMenuSceneLoadedEvent;
        GameManager.gameSceneLoadedEvent += OnGameSceneLoadedEvent;
        sceneLoadingManagerInstance.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void OnDestroy() {
        MainMenuManager.mainMenuSceneLoadedEvent -= OnMainMenuSceneLoadedEvent;
        GameManager.gameSceneLoadedEvent -= OnGameSceneLoadedEvent;
    }

    public void RegisterMainMenuManager(MainMenuManager mainMenuManager) {
        this.mainMenuManager = mainMenuManager;
    }

    private void OnMainMenuSceneLoadedEvent(MainMenuManager mainMenuManager) {
        mainMenuManager.Setup(appManager);
    }

    public void RegisterGameManager(GameManager gameManager) {
        this.gameManager = gameManager;
    }

    private void OnGameSceneLoadedEvent(GameManager gameManager) {
        gameManager.Setup(appManager);
    }
}
