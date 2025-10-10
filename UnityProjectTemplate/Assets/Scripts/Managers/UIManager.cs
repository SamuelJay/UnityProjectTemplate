using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour, IApp {
    void OnEnable() {
        Services.Register<IApp>(this);
        Services.Register<IEventBus>(GetComponentInChildren<EventManager>() ?? gameObject.AddComponent<EventManager>());
        // same for scene/UI services – or assign via inspector once
    }
}

public class UIManager : Manager {
    public MainMenuCanvas mainMenuCanvas { get; private set; }
    public GameCanvas gameCanvas { get; private set; }

    public override void Setup(AppManager appManager) {
        base.Setup(appManager);
    }

    public void RegisterMainMenuCanvas(MainMenuCanvas mainMenuCanvas) {
        this.mainMenuCanvas = mainMenuCanvas;
        mainMenuCanvas.Setup(appManager);
    }
    
    public void RegisterGameCanvas(GameCanvas gameCanvas) {
        this.gameCanvas = gameCanvas;
        gameCanvas.Setup(appManager);
    }
}