using UnityEngine;

public sealed class FrameworkBootstrapper : MonoBehaviour {
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init() {
        // Optionally create a persistent GameObject holding AppManager if none exists
        if (FindFirstObjectByType<AppManager>() == null) {
            /* var go0 = new GameObject("[AppManager]");
             DontDestroyOnLoad(go0);*//*
             go0.AddComponent<AppManager>(); // AppManager registers itself in OnEnable*/
        }
        if (FindFirstObjectByType<EventManager>() == null) {
            var go2 = new GameObject("[EventManager]");
            DontDestroyOnLoad(go2);
            go2.AddComponent<EventManager>(); // EventManager registers itself in OnEnable
        }
        if (FindFirstObjectByType<EventManager>() == null) {
            var go3 = new GameObject("[EventManagerNew]");
            DontDestroyOnLoad(go3);
            go3.AddComponent<EventManager>(); // EventManager registers itself in OnEnable
        }
        if (FindFirstObjectByType<SceneLoadingManager>() == null) {
            var go1 = new GameObject("[SceneLoadingManager]");
            DontDestroyOnLoad(go1);
            go1.AddComponent<SceneLoadingManager>(); // SceneLoadingManager registers itself in OnEnable}
        }
    }
}