using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneState
{
    //This state representes a "Scene"

    public abstract Actor GetTarget(Actor target);
    public abstract Actor OnDead(Actor target);
}
