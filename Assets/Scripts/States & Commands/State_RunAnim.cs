using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_RunAnim : IState
{
    private Actor actor;
    private SceneState state;

    public State_RunAnim(Actor actor, SceneState state)
    {
        this.actor = actor;
        this.state = state;
    }
    public void HandleInput() { }

    public void OnEnter()
    {
        // gets and sets combat animations
    }
    public void OnExit()
    {

    }
    public void UpdateState()
    {
        // updates animations?
    }
    /*
    public bool IsFinished()
    {
        // gets whether an animation is finished or not and returns boolean result
    }*/
}