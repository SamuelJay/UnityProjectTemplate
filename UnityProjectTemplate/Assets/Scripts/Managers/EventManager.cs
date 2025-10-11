using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : Manager, IEvents
{
    private readonly Dictionary<Type, Delegate> map = new();
   
    private void OnEnable() {
        Services.RegisterApp<IEvents>(this);
    }
    public void StartListening<T>(Action<T> callback) where T : BaseEvent {
        Type classType = typeof(T);
        map[classType] = Delegate.Combine(map.GetValueOrDefault(classType), callback);
    }
    public void StopListening<T>(Action<T> callback) where T : BaseEvent {
        Type classType = typeof(T);
        
        if (!map.TryGetValue(classType, out Delegate eventDelegate)) return;
        
        eventDelegate = Delegate.Remove(eventDelegate, callback);
        
        if (eventDelegate == null) map.Remove(classType);
        
        else map[classType] = eventDelegate;
    }
    public void Trigger<T>(T eventReference) where T : BaseEvent {
        if (map.TryGetValue(typeof(T), out Delegate eventDelegate)) ((Action<T>)eventDelegate)?.Invoke(eventReference);
    }
}
