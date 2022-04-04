using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Technique : ICommand
{
    public int Countdown { get; set; }
    public string Name { get; set; }
    public string Owner { get; set; }

    // needs a technique interface
    // will access a list of techniques

    public void Execute()
    {

    }
    public void UpdateEvent()
    {

    }
    public bool IsFinished()
    {
        // This is where code will go that determines if a command is usable or not
        // placing a default variable for now
        bool isFinished = true;
        return isFinished;
    }
}
