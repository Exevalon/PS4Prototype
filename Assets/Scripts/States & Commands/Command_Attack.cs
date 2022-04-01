using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Attack : ICommand
{
    public GameObject Source { get; set; }
    public GameObject Target { get; set; }
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
