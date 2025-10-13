using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class FrameworkBootstrapper : MonoBehaviour {
    private const string defaultPath = "Framework/BootstrapData"; // Resources path
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void InitBeforeSceneLoaded() {
        BootstrapData profile = Resources.Load<BootstrapData>(defaultPath);
        SceneManager.activeSceneChanged += (_, __) => Services.ResetSceneScope();
        Bootstrapper.RunBeforeSceneLoaded(profile);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void InitAfterSceneLoaded() {
        BootstrapData profile = Resources.Load<BootstrapData>(defaultPath);
        Bootstrapper.RunAfterSceneLoaded(profile);
    }
}