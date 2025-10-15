using UnityEngine;
using UnityEngine.SceneManagement;

public interface IScenes {
    public bool SceneAlreadyLoaded(string sceneName);
    public void LoadScene(string name, LoadSceneMode mode);

    public void UnLoadScene(string name);

    public void SetActiveScene(string name);
}
