using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Guard : ICommand
{
    public int Countdown { get; set; }
    public string Name { get; set; }
    public Actor Owner { get; set; }

    public int TimePoints(CommandQueue queue)
    {
        int speed = Owner.ActorSpeed;
        return queue.SpeedToTimePoints(speed);
    }

    public void Execute(CommandQueue queue)
    {

    }
    public void UpdateCommand() { }
    public bool IsFinished(bool check)
    {
        return check;
    }
}
