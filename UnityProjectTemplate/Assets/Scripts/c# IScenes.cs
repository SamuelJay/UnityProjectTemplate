using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IScenes {
    void Load(string name, LoadSceneMode mode);
    void Unload(string name);
    void SetActive(string name);

}