using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Technique : ICommand
{
    public int Countdown { get; set; }
    public string Name { get; set; }
    public Actor Owner { get; set; }

    // this will take a list of techniques
    // will also implement a technique interface

    public int TimePoints(CommandQueue queue)
    {
        int speed = Owner.ActorSpeed;
        return queue.SpeedToTimePoints(speed);
    }

    public void Execute(CommandQueue queue)
    {

    }
    public void UpdateCommand()
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
