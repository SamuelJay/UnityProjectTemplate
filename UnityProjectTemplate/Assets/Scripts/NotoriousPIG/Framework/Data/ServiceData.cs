using System;
using UnityEngine;

namespace NotoriousPIG.Framework {
    public enum ServiceLifetime { App, Scene }

    [Serializable]
    public class ServiceData {
        public MonoBehaviour prefab;         // a prefab with a component implementing one or more interfaces
        public ServiceLifetime lifetime;     // App or Scene
        public string[] interfacesToRegister; // e.g. "IEventBus", "IScenes"
    }
}