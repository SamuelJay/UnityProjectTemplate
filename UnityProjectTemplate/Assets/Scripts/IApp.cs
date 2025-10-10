using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IApp {
    
    void MainMenu(string name, LoadSceneMode mode);
    void Game(string name);
    void SetActive(string name);
}
