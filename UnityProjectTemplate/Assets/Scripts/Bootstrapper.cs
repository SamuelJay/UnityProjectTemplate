using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class Bootstrapper {
    

    public static void RunBeforeSceneLoaded(BootstrapData profile) {
        
        if (profile == null) {
            Debug.LogWarning("No BootstrapProfile found.");
            return;
        }

        // Instantiate app-level services (DDOL)
        foreach (ServiceData service in profile.appServices) {
            MonoBehaviour instance = Object.Instantiate(service.prefab);
            Object.DontDestroyOnLoad(instance.gameObject);
            RegisterInterfaces(instance, service.interfacesToRegister, app: true);
        }

      
    }

    public static void RunAfterSceneLoaded(BootstrapData profile) {
        // Optionally instantiate initial scene-level services (rarely needed)
        Scene active = SceneManager.GetActiveScene();
        // Load first scene if not already there
        if (!string.IsNullOrEmpty(profile.initialSceneName) &&
            !string.Equals(active.name, profile.initialSceneName, StringComparison.Ordinal)) {
            Services.Get<IScenes>().LoadScene(profile.initialSceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);

        }
        foreach (ServiceData service in profile.sceneServices) {
            MonoBehaviour instance = Object.Instantiate(service.prefab);
            RegisterInterfaces(instance, service.interfacesToRegister, app: false);
        }

    }

    private static void RegisterInterfaces(MonoBehaviour instance, string[] ifaceNames, bool app) {
        Type type = instance.GetType();
        Dictionary<string, Type> implemented = type.GetInterfaces().ToDictionary(t => t.Name, t => t);

        foreach (string name in ifaceNames) {
            if (implemented.TryGetValue(name, out Type interfaceType)) {
                object asInterface = Convert.ChangeType(instance, interfaceType);

                if (app) typeof(Services).GetMethod("RegisterApp").MakeGenericMethod(interfaceType).Invoke(null, new[] { asInterface });

                else typeof(Services).GetMethod("RegisterScene").MakeGenericMethod(interfaceType).Invoke(null, new[] { asInterface });

            } else {
                Debug.LogError($"{type.Name} does not implement interface {name}");
            }
        }
    }
}
