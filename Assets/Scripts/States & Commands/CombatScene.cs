using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScene : SceneState
{
    public override Actor GetTarget(Actor target)
    {
        // needs to return a target list
        return target;
    }

    public override Actor OnDead(Actor target)
    {
        // Does cleanup
        throw new System.NotImplementedException();
    }
}
