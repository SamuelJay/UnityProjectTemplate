using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseBehaviour : MonoBehaviour {
    protected IUI UI => Services.Get<IUI>();
    protected IScenes Scenes => Services.Get<IScenes>();
    protected IEventBus Bus => Services.Get<IEventBus>();

   }
