using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : Manager
{
    public EventManager eventManager { get; private set; }
    public SceneLoadingManager sceneLoadingManager { get; private set; }
    public UIManager uiManager { get; private set; }
    public MainMenuManager mainMenuManager { get; private set; }
    public GameManager gameManager { get; private set; }

    [SerializeField] private EventManager eventManagerPrefab;
    [SerializeField] private SceneLoadingManager sceneLoadingManagerPrefab;
    [SerializeField] private UIManager uiManagerPrefab;
    [SerializeField] private MainMenuManager mainMenuManagerPrefab;
    [SerializeField] private GameManager gameManagerPrefab;

    private void Awake()
    {
        Setup(this);
    }

    public override void Setup(AppManager appManager)
    {
        base.Setup(appManager);
        eventManager = Instantiate(eventManagerPrefab);
        sceneLoadingManager = Instantiate(sceneLoadingManagerPrefab);
        uiManager = Instantiate(uiManagerPrefab);

        DontDestroyOnLoad(this);
        DontDestroyOnLoad(eventManager);
        DontDestroyOnLoad(sceneLoadingManager);
        DontDestroyOnLoad(uiManager);
        
        eventManager.Setup(this);
        sceneLoadingManager.Setup(this);
        uiManager.Setup(this);

        StartListeningToEvent<SceneLoadedEvent>(OnSceneLoadedEvent);
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void OnSceneLoadedEvent(object sender, EventArgs data)
    {
        SceneLoadedEvent sceneLoadedEvent = data as SceneLoadedEvent;
        switch (sceneLoadedEvent.scene.name)
        {
            case "MainMenu":
                SetupMainMenu();
                break;
            case "Game":
                SetupGame();
                break;
        };
    }

    private void SetupMainMenu()
    {
        mainMenuManager = Instantiate(mainMenuManagerPrefab);
        mainMenuManager.Setup(this);
    }

    private void SetupGame()
    {
        gameManager = Instantiate(gameManagerPrefab);
        gameManager.Setup(this);
    }
}
