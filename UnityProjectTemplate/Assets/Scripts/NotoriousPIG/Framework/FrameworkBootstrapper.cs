using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class FrameworkBootstrapper : MonoBehaviour {

    private const string defaultPath = "Framework/BootstrapData"; // Resources path
    private static bool _subscribed; // prevents duplicate subscriptions across play sessions

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void InitBeforeSceneLoaded() {
        
        // Ensure fresh scopes at session start (important with Domain Reload OFF)
        Services.ResetAppScope();
        Services.ResetSceneScope();

        // Subscribe once to scene change events (guarded)
        if (!_subscribed) {
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
            _subscribed = true;

#if UNITY_EDITOR
            // Clean up when exiting play (so next Play re-subscribes exactly once)
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
#endif
        }

        // Load bootstrap profile & run pre-scene logic
        BootstrapData profile = Resources.Load<BootstrapData>(defaultPath);
        Bootstrapper.RunBeforeSceneLoaded(profile);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void InitAfterSceneLoaded() {
        BootstrapData profile = Resources.Load<BootstrapData>(defaultPath);
        Bootstrapper.RunAfterSceneLoaded(profile);
    }

    private static void OnActiveSceneChanged(Scene oldScene, Scene newScene) {
        // Rebuild scene scope whenever the active scene flips
        Services.ResetSceneScope();
    }

#if UNITY_EDITOR
    private static void OnPlayModeStateChanged(PlayModeStateChange state) {
        if (state == PlayModeStateChange.ExitingPlayMode) {
            // Unhook to avoid duplicate subscriptions next Play (Domain Reload OFF)
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            _subscribed = false;

            // Optional: also reset scopes to leave things tidy between plays
            Services.ResetAppScope();
            Services.ResetSceneScope();
        }
    }
#endif
}