using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : Manager
{
    [SerializeField] private GameObject eventManagerPrefab;
    [SerializeField] private GameObject sceneLoadingManagerPrefab;
    [SerializeField] private GameObject uiManagerPrefab;
    [SerializeField] private GameObject mainMenuManagerPrefab;
    [SerializeField] private GameObject gameManagerPrefab;
}
