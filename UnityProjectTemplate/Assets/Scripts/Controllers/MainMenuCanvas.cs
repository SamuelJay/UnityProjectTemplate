using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvas : Controller {
    
    [SerializeField] private Button startButton;

    private void OnEnable() {
        Setup();
    }

    private void Setup() {
        startButton.onClick.AddListener(StartButtonPressed);
    }


    private void OnDestroy() {
        startButton.onClick.RemoveListener(StartButtonPressed);
    }

    private void StartButtonPressed() {
        TriggerEvent<StartButtonPressedEvent>(new StartButtonPressedEvent());
    }
}
