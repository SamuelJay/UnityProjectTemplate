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
        Services.RegisterScene<IGame>(this);
        Setup();
    }

    public void Setup() {
        StartListeningToEvent<ExitButtonPressedEvent>(OnExitButtonPressedEvent);
        Services.Get<IEvents>().Trigger( new TestGameStartedEvent());
    }


    private void OnDestroy() {
        StopListeningToEvent<ExitButtonPressedEvent>(OnExitButtonPressedEvent);
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            TriggerEvent(new ExitButtonPressedEvent());
        }
    }

    private void OnExitButtonPressedEvent(ExitButtonPressedEvent @event) {
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
