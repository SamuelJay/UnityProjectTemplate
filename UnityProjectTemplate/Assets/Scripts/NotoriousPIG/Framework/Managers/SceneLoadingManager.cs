using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NotoriousPIG.Framework.Examples {
    public class SceneLoadingManager : Manager, IScenes {
        private void Setup() {
            Services.Get<IEvents>().StartListening<TestGameStartedEvent>(OnTestGameStartedEvent);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnTestGameStartedEvent(TestGameStartedEvent @event) {
            Debug.Log("HOW IT WORK");
        }

        private void OnEnable() {
            Services.RegisterApp<IScenes>(this);
            Setup();
        }

        private void OnDestroy() {
            Services.UnregisterApp<IScenes>(this);
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            Debug.Log($"SceneLoadingManager OnSceneLoaded {scene.name}");
            //Services.LogScopes();
            TriggerEvent(new SceneLoadedEvent(scene, mode));
        }

        public bool SceneAlreadyLoaded(string sceneName) {
            for (int i = 0; i < SceneManager.sceneCount; i++) {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.name == sceneName && scene.isLoaded) {
                    return true;
                }
            }
            return false;
        }


        public void LoadScene(string name, LoadSceneMode mode) {
            //Debug.Log($"SceneLoadingManager LoadScene {name}");
            //Services.LogScopes();
            SceneManager.LoadScene(name, mode);
        }

        public void UnLoadScene(string name) {
            //Debug.Log($"SceneLoadingManager UnLoadScene {name}");
            //Services.LogScopes();
            SceneManager.UnloadSceneAsync(name);
        }

        public void SetActiveScene(string name) {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
        }
    }
}