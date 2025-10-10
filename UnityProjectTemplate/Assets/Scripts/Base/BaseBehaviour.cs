using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour {
    protected IScenes sceneLoadingManager => Services.Get<IScenes>();
    private IEventBus eventManager => Services.Get<IEventBus>();

    /*public virtual void Setup(AppManager appManager) {
        this.appManager = appManager;
    }*/

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
