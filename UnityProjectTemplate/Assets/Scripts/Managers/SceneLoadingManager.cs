using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager : Manager, IScenes {
    private void Setup() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnEnable() {
        Services.Register<IScenes>(this);
        Setup();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        TriggerEvent<SceneLoadedEvent>(new SceneLoadedEvent(scene, mode));
    }

    public void LoadScene(string name, LoadSceneMode mode) {
        SceneManager.LoadScene(name, mode);
    }

    public void UnLoadScene(string name) {
        SceneManager.UnloadSceneAsync(name);
    }

    public void SetActiveScene(string name) {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
    }
}