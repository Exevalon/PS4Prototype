using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTargetState : MonoBehaviour, IState
{
    /*  In this class we define targets for our selection
     *  and check which side our targets are on
     *  and execute callbacks
     *  We then add our action to the command queue
     *  This is what is called when we decide on a course of action:
     *  Whether to attack, defend, use a tech, skill, or item
     *  We can also back out back to the top level menu if wanted
     */

    // An enum for target sides
    public enum Sides
    {
        partySide,
        enemySide,
        allSides
    }

    private Sides sideSelection = Sides.enemySide;
    private Actor actor;
    private IState state;

    //Create function or constructor
    public void CreateCombatTargetState(Actor actor, IState state)
    {
        this.actor = actor;
        this.state = state;
    }

    // On Enter, takes an Actor
    public void OnEnter() { }

    // On Exit, clean up
    public void OnExit() { }

    // HandleInput
    public void HandleInput() { }

    // GetActorList, helper function that takes an actor and returns a list
    /*
    public List<Actor> GetActorList(Actor actor)
    {
        return actor list
    }*/

    public void UpdateState() { }
}
