using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager
{
    private AppManager appManager => manager as AppManager;
    private SceneLoadingManager sceneLoadingManager => appManager.sceneLoadingManager;

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        StartListeningToEvent<ExitButtonPressedEvent>(OnExitButtonPressedEvent);
    }
    private void OnExitButtonPressedEvent(object sender, EventArgs data)
    {
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) 
        {
            TriggerEvent<ExitButtonPressedEvent>(new ExitButtonPressedEvent());
        }
    }
}
