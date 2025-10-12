using UnityEngine;

[CreateAssetMenu(fileName = "BootstrapData", menuName = "Scriptable Objects/BootstrapData")]
public class BootstrapData : ScriptableObject {
    public string initialSceneName = "MainMenu";
    public ServiceData[] appServices;   // DDOL singletons
    public ServiceData[] sceneServices; // optional per-initial scene spawn
}
