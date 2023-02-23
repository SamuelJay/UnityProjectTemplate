using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : Manager
{
    public EventManager eventManager { get; private set; }
    public SceneLoadingManager sceneLoadingManager { get; private set; }
    public UIManager uiManager { get; private set; }
    public MainMenuManager mainMenuManager { get; private set; }
    public GameManager gameManager { get; private set; }

    [SerializeField] private GameObject eventManagerPrefab;
    [SerializeField] private GameObject sceneLoadingManagerPrefab;
    [SerializeField] private GameObject uiManagerPrefab;
    [SerializeField] private GameObject mainMenuManagerPrefab;
    [SerializeField] private GameObject gameManagerPrefab;

    private void Awake()
    {
        Setup(this);
    }

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        GameObject eventManagerObject = Instantiate(eventManagerPrefab);
        GameObject sceneLoadingManagerObject = Instantiate(sceneLoadingManagerPrefab);
        GameObject uiManagerObject = Instantiate(uiManagerPrefab);

        DontDestroyOnLoad(this);
        DontDestroyOnLoad(eventManagerObject);
        DontDestroyOnLoad(sceneLoadingManagerObject);
        DontDestroyOnLoad(uiManagerObject);

        eventManager = eventManagerObject.GetComponent<EventManager>();
        sceneLoadingManager = sceneLoadingManagerObject.GetComponent<SceneLoadingManager>();
        uiManager = uiManagerObject.GetComponent<UIManager>();

        eventManager.Setup(this);
        sceneLoadingManager.Setup(this);
        uiManager.Setup(this);

        
    }

    private void SetupMainMenu()
    {
        GameObject mainMenuManagerObject = Instantiate(mainMenuManagerPrefab);
        mainMenuManager = mainMenuManagerObject.GetComponent<MainMenuManager>();
        mainMenuManager.Setup(this);
    }

    private void SetupGame()
    {
        GameObject gameManagerObject = Instantiate(gameManagerPrefab);
        gameManager = gameManagerObject.GetComponent<GameManager>();
        gameManager.Setup(this);
    }
}
