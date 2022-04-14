using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Hurt : IState
{
    private Actor actor;
    private SceneState state;

    public State_Hurt(Actor actor, SceneState state)
    {
        this.actor = actor;
        this.state = state;
    }
    public void HandleInput()
    {

    }
    public void OnEnter()
    {

    }
    public void OnExit()
    {

    }
    public void UpdateState()
    {

    }
}