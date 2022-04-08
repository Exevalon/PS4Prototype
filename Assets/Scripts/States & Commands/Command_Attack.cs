using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Attack : ICommand
{
    public int Countdown { get; set; }
    public string Name { get; set; }
    public Actor Owner { get; set; }
    public Actor Target { get; set; }

    // This needs to be a scene type that will be determined later
    private SceneState sceneState;

    public Command_Attack(SceneState sceneState, Actor owner, Actor target)
    {
        this.sceneState = sceneState;
        Owner = owner;
        Target = target;
        Name = $"Command Attack: {Owner.ActorName}, {Target.ActorName}";
    }

    public int TimePoints(CommandQueue queue)
    {
        int speed = Owner.ActorSpeed;
        return queue.SpeedToTimePoints(speed);
    }

    public void Execute(CommandQueue queue)
    {
        Actor target = Target;

        if (target.HP <= 0)
            target = sceneState.GetTarget(Owner);

        int damage = Owner.AttackPower;
        target.HP -= damage;

        string msg = $"{Owner} hit {target.ActorName} for {damage}";
        Debug.Log(msg);

        if(target.HP <= 0)
        {
            string msg2 = $"{target.ActorName} has been whacked";
            Debug.Log(msg2);
            sceneState.OnDead(target);
        }
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
