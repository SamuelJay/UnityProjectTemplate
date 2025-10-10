using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager, IGame
{
    [SerializeField] private GameCanvas gameCanvas;

    private void OnEnable() {
        Services.Register<IGame>(this);
        Setup();
    }

    public void Setup() {
        StartListeningToEvent<ExitButtonPressedEvent>(OnExitButtonPressedEvent);
    }

    

    private void OnDestroy() {
        StopListeningToEvent<ExitButtonPressedEvent>(OnExitButtonPressedEvent);
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            TriggerEvent<ExitButtonPressedEvent>(new ExitButtonPressedEvent());
        }
    }

    private void OnExitButtonPressedEvent(object sender, EventArgs data) {
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
