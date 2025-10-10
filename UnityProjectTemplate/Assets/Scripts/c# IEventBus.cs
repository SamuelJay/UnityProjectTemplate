using System;
using System.Collections.Generic;
using UnityEngine;


public interface IEventBus {
    void Subscribe<T>(EventHandler cb);
    void Unsubscribe<T>(EventHandler cb);
    void Publish<T>(BaseEvent e);
}