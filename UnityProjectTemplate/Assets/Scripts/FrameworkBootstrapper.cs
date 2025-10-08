using UnityEngine;

public sealed class FrameworkBootstrapper : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        // Optionally create a persistent GameObject holding AppManager if none exists
        if (FindFirstObjectByType<AppManager>() == null)
        {
            var go = new GameObject("[AppManager]");
            DontDestroyOnLoad(go);
            go.AddComponent<AppManager>(); // AppManager registers itself in OnEnable
        }
    }
}