using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Standby : IState
{
    private Actor actor;
    private SceneState state;

    public State_Standby(Actor actor, SceneState state)
    {
        this.actor = actor;
        this.state = state;
    }
    public void HandleInput() { }

    public void OnEnter()
    {
        // plays idle animation
    }
    public void OnExit()
    {

    }
    public void UpdateState()
    {
        // updates animation?
    }
}
