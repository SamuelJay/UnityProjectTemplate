using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager
{
    private SceneLoadingManager sceneLoadingManager => appManager.sceneLoadingManager;

    public override void Setup(AppManager appManager)
    {
        base.Setup(appManager);
        StartListeningToEvent<ExitButtonPressedEvent>(OnExitButtonPressedEvent);
    }
    private void OnExitButtonPressedEvent(object sender, EventArgs e)
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
