using System;
using System.Collections.Generic;
using UnityEngine;

public static class Services {
    private static readonly Dictionary<Type, object> map = new();
    public static void Register<T>(T instance) where T : class => map[typeof(T)] = instance;
    public static bool TryGet<T>(out T value) where T : class {
        if (map.TryGetValue(typeof(T), out object obj)) {
            value = (T)obj;
            return true;
        }
        value = null;
        return false;
    }
    public static T Get<T>() where T : class => (T)map[typeof(T)];
}
