using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Technique : ICommand
{
    public GameObject Source { get; set; }
    public GameObject Target { get; set; }

    // needs a technique interface
    // will access a list of techniques

    public void HandleInput()
    {

    }
    public void OnEnter()
    {

    }
    public void OnExit()
    {

    }
    public bool IsUsable()
    {
        // This is where code will go that determines if a command is usable or not
        // placing a default variable for now
        bool isUsable = true;
        return isUsable;
    }
}
