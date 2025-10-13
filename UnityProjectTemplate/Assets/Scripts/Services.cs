using System;
using System.Collections.Generic;
using UnityEngine;

public static class Services {
    private static readonly Dictionary<Type, object> app = new();
    private static Dictionary<Type, object> scene = new();

    public static bool TryGet<T>(out T value) where T : class {
        if (scene.TryGetValue(typeof(T), out object sceneService)) {
            value = (T)sceneService;
            return true;
        }
        if (app.TryGetValue(typeof(T), out object appService)) {
            value = (T)appService;
            return true;
        }
        value = null;
        return false;
    }

    public static T Get<T>() where T : class =>
        TryGet<T>(out T value) ? value :
        throw new InvalidOperationException(
            $"No service for {typeof(T).Name}. (Check scene/app registration.)" +
            $"If this should be app-wide, ensure it’s registered in Bootstrap. " +
            $"If scene-scoped, confirm the scene manager registers it in OnEnable."
        );

    public static void RegisterApp<T>(T instance) where T : class => app[typeof(T)] = instance;

    public static void RegisterScene<T>(T instance) where T : class => scene[typeof(T)] = instance;

    public static void UnregisterApp<T>(T inst) where T : class {
        if (app.TryGetValue(typeof(T), out var cur) && ReferenceEquals(cur, inst))
            app.Remove(typeof(T));
    }
    public static void UnregisterScene<T>(T inst) where T : class {
        if (scene.TryGetValue(typeof(T), out var cur) && ReferenceEquals(cur, inst))
            scene.Remove(typeof(T));
    }


    internal static void ResetSceneScope() => scene = new Dictionary<Type, object>();

    public static void LogScopes() {
        Debug.Log("App Services Registered");
        string appScopes = "";
        foreach (var k in app.Keys) {
            appScopes += $"Key {k} Value: {app[k]} ";
        }
        Debug.Log($"{appScopes}");

        string sceneScopes = "";
        Debug.Log("Scene Services Registered");
        foreach (var k in scene.Keys) {
            sceneScopes += $"Key {k} Value: {scene[k]} ";
        }
        Debug.Log($"{sceneScopes}");
    }
}