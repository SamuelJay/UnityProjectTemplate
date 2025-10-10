using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager, IUI {
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