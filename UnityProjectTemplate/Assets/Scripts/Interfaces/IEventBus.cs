using System;
using UnityEngine;

public interface IEventBus
{
    public void StartListening<T>(EventHandler callBack);
    public void StopListening<T>(EventHandler callBack);

    public void Trigger<T>(BaseEvent eventArgs);
}
