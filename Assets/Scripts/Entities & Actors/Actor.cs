using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// May have this inherit from monobehaviour
public class Actor
{
    // Core stats and characteristics
    public bool isPlayer { get; set; }
    public string ActorName { get; set; }
    public int HP { get; set; }
    public int TP { get; set; }
    public int AttackPower { get; set; }
    public int DefensePower { get; set; }
    public int ActorSpeed { get; set; }

    // For rendering purposes
    public ModelView Model { get; set; }
    public Sprite Sprite { get; set; }
    public string sortingLayer { get; set; }
    public int order { get; set; }

    // Every actor will have animations for combat: idle, attack, technique, item, etc
    // will need to be fed to the model view

    // For enemy layout positioning
    // Enemies will come in either small, medium, large, or extra-large sizes
    public string Size { get; set; }

    // The command the actor can do
    public ICommand Command { get; set; }

    // Set the state
    public ActorStates.actorStates state;

    public bool IsKOed()
    {
        return HP <= 0;
    }

    public void IsKO()
    {
        //do something on death
        Debug.Log("Dead");
    }

    public bool IsPlayer(bool isPlayer)
    {
        this.isPlayer = isPlayer;

        return this.isPlayer;
    }

    public void UpdateActorState(ActorStates.actorStates state)
    {
        this.state = state;
        Debug.Log($"{ActorName} is in the {this.state} state");
    }
}
