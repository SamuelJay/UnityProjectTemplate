using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotoriousPIG.Framework.Examples {
    public class BaseBehaviour : MonoBehaviour {
        protected IScenes sceneLoadingManager => Services.Get<IScenes>();
        private IEvents eventManager => Services.Get<IEvents>();

        /*public virtual void Setup(AppManager appManager) {
            this.appManager = appManager;
        }*/

        public void StartListeningToEvent<T>(Action<T> callback) where T : BaseEvent {
            eventManager.StartListening(callback);
        }

        public void StopListeningToEvent<T>(Action<T> callback) where T : BaseEvent {
            eventManager.StopListening(callback);
        }

        public void TriggerEvent<T>(T eventArgs) where T : BaseEvent {
            eventManager.Trigger(eventArgs);
        }
    }
}