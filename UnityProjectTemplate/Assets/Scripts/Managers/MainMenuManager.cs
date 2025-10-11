using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : Manager, IMainMenu {
  
    [SerializeField] private MainMenuCanvas mainMenuCanvas;

    private void OnEnable() {
        Services.RegisterScene<IMainMenu>(this);
        Setup();
    }

    private void Setup() {
        
        print("MainMenuSceneManager Setup");
        
        StartListeningToEvent<StartButtonPressedEvent>(OnStartButtonPressedEvent);
    }


    private void OnDestroy() {
        StopListeningToEvent<StartButtonPressedEvent>(OnStartButtonPressedEvent);
    }

    private void OnStartButtonPressedEvent(StartButtonPressedEvent @event) {
        sceneLoadingManager.LoadScene("Game", LoadSceneMode.Single);
    }
}