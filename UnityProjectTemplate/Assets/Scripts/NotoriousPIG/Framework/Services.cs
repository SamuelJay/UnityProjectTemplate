using System;
using System.Collections.Generic;
using UnityEngine;

public static class Services {
    private static readonly Dictionary<Type, object> app = new();
    private static Dictionary<Type, object> scene = new();

    public static bool TryGet<T>(out T value) where T : class {
        Type key = typeof(T);

        // Scene-scope first
        if (scene.TryGetValue(key, out object sceneObj)) {
            if (!IsDeadUnityObject(sceneObj)) {
                value = (T)sceneObj;
                return true;
            }
            scene.Remove(key); // purge dead
        }

        // App-scope second
        if (app.TryGetValue(key, out object appObj)) {
            if (!IsDeadUnityObject(appObj)) {
                value = (T)appObj;
                return true;
            }
            app.Remove(key); // purge dead
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

    public static void RegisterApp<T>(T instance) where T : class {
        Type key = typeof(T);
#if UNITY_EDITOR
        WarnIfOverwriting(app, key, instance);
#endif
        app[key] = instance;
    }

    public static void RegisterScene<T>(T instance) where T : class {
        Type key = typeof(T);
#if UNITY_EDITOR
        WarnIfOverwriting(scene, key, instance);
#endif
        scene[key] = instance;
    }

    public static void UnregisterApp<T>(T instance) where T : class {

        Type key = typeof(T);

        if (app.TryGetValue(key, out object current) && ReferenceEquals(current, instance)) app.Remove(key);
    }

    public static void UnregisterScene<T>(T instance) where T : class {

        Type key = typeof(T);

        if (scene.TryGetValue(key, out object current) && ReferenceEquals(current, instance)) scene.Remove(key);
    }

    public static void ResetAppScope() => app.Clear();
    public static void ResetSceneScope() => scene = new Dictionary<Type, object>();

    public static void LogScopes() {
        Debug.Log("App Services Registered");
        string appScopes = "";
        foreach (Type k in app.Keys) {
            appScopes += $"Key {k} Value: {app[k]} ";
        }
        Debug.Log($"{appScopes}");

        string sceneScopes = "";
        Debug.Log("Scene Services Registered");
        foreach (Type k in scene.Keys) {
            sceneScopes += $"Key {k} Value: {scene[k]} ";
        }
        Debug.Log($"{sceneScopes}");
    }

    // ------------- HELPERS -------------

    private static bool IsDeadUnityObject(object obj) {
        if (obj is UnityEngine.Object unityObject) return unityObject == null; // Unity’s “fake null” comparison
        return false;
    }

#if UNITY_EDITOR
    private static void WarnIfOverwriting(IDictionary<Type, object> dict, Type key, object newInstance) {
        if (dict.TryGetValue(key, out var existing) && !ReferenceEquals(existing, newInstance)) {
            Debug.LogWarning($"[Services] Overwriting registration for {key.Name}. " +
                             $"Old: {existing}, New: {newInstance}");
        }
    }
#endif
}