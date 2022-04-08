using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Turn : ICommand
{
    public int Countdown { get; set; }
    public string Name { get; set; }
    public Actor Owner { get; set; }

    // This needs to be a scene type that will be determined later
    private SceneState sceneState;

    // I'm unsure if the owner here needs to be a gameobject actor
    public Command_Turn(SceneState sceneState, Actor actor)
    {
        this.sceneState = sceneState;
        Owner = actor;
        Name = $"CommandTurn: {Owner.ActorName}";
    }

    public int TimePoints(CommandQueue queue)
    {
        int speed = Owner.ActorSpeed;
        return queue.SpeedToTimePoints(speed);
    }

    public void Execute(CommandQueue queue)
    {
        // We choose a rando guy
        Actor target = sceneState.GetTarget(Owner);
        string msg = $"{Owner.ActorName} decides to wreck {target.ActorName}";
        Debug.Log(msg);

        // This is the place we pass in the command we care about
        ICommand command = new Command_Attack(sceneState, Owner, target);
        int timePoints = TimePoints(queue);
        queue.Add(command, timePoints);
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
