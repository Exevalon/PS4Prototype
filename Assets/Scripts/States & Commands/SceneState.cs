using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneState
{
    //This state representes a "Scene" that will handle a series of events and clean up

    public abstract void UpdateScene();
    public abstract bool IsPartyDefeated();
    public abstract Actor GetTarget(Actor target);
    public abstract List<Actor> GetLivePartyActors();
    public abstract void OnDead(Actor target);
    public abstract bool IsPartyMember(Actor actor);
}
