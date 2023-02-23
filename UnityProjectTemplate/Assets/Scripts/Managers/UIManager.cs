using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager
{
    [SerializeField] private GameObject mainMenuCanvasPrefab;
    private MainMenuCanvasController mainMenuCanvasController;
    [SerializeField] private GameObject gameCanvasPrefab;
    //private GameCanvasController gameCanvasController;

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
    }

    public void SetupMainMenuUI()
    {
        GameObject mainMenuCanvasObject = Instantiate(mainMenuCanvasPrefab);
        mainMenuCanvasController = mainMenuCanvasObject.GetComponent<MainMenuCanvasController>();
        mainMenuCanvasController.Setup(manager);
    }

    public void SetupGameUI()
    {
        GameObject gameCanvasObject = Instantiate(gameCanvasPrefab);
        //gameCanvasController = gameCanvasObject.GetComponent<GameCanvasController>();
        //gameCanvasController.Setup(manager);
    }
}
