using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour {
    public AppManager appManager { get; private set; }
    protected UIManager uiManager => appManager.uiManagerInstance;
    protected SceneLoadingManager sceneLoadingManager => appManager.sceneLoadingManagerInstance;
    private EventManager eventManager => appManager.eventManagerInstance;

    public virtual void Setup(AppManager appManager) {
        this.appManager = appManager;
    }

    public void StartListeningToEvent<T>(EventHandler callback) {
        eventManager.StartListening<T>(callback);
    }

    public void StopListeningToEvent<T>(EventHandler callback) {
        eventManager.StopListening<T>(callback);
    }

    public void TriggerEvent<T>(BaseEvent eventArgs) {
        eventManager.Trigger<T>(eventArgs);
    }
}
