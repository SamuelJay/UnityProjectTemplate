using System;
using UnityEngine;

namespace NotoriousPIG.Framework {
    public interface IEvents {
        void StartListening<T>(Action<T> handler) where T : BaseEvent;
        void StopListening<T>(Action<T> handler) where T : BaseEvent;
        void Trigger<T>(T evt) where T : BaseEvent;
    }
}