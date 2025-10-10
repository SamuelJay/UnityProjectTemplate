using System;
using System.Collections.Generic;
using UnityEngine;

public interface IUI {
    MainMenuCanvas MainMenu { get; }
    GameCanvas Game { get; }
}
