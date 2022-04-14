using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CommandQueue
{
    private ICommand currentCommand;
    public List<ICommand> commandList;

    public void Create()
    {
        commandList = new List<ICommand>();
        currentCommand = null;
    }

    public int SpeedToTimePoints(int speed)
    {
        int maxSpeed = 255;
        speed = Mathf.Min(speed, maxSpeed);
        int points = maxSpeed - speed;
        return points;
    }

    public void Add(ICommand command, int timePoints)
    {
        List<ICommand> localList = commandList;

        // Add instant command event and place it at the top of the queue
        if (timePoints == -1)
        {
            command.Countdown = -1;
            localList.Insert(0, command);
        }
        else
        {
            command.Countdown = timePoints;

            // Loop through the commands
            for (int i = 0; i < localList.Count; i++)
            {
                int timeCount = localList[i].Countdown;
                if (timeCount > command.Countdown)
                {
                    localList.Insert(i, command);
                    return;
                }
            }
            localList.Add(command);
        }
    }
    
    public bool ActorHasCommand(Actor actor)
    {
        ICommand current = currentCommand == null ? new Command() : currentCommand;

        if (current.Owner == actor)
            return true;

        foreach(ICommand command in commandList)
        {
            if (command.Owner == actor)
                return true;
        }

        return false;
    }
    
    public void RemoveCommandsByActor(Actor actor)
    {
        for(int i = commandList.Count - 1; i > 0; i--)
        {
            ICommand command = commandList[i];
            if(command.Owner == actor)
                commandList.RemoveAt(i);
        }
    }

    public void ClearCommandList()
    {
        commandList.Clear();
        currentCommand = null;
    }

    public bool IsEmpty()
    {
        return commandList.Count == 0;
    }

    public void Print()
    {
        List<ICommand> localList = commandList;

        if (IsEmpty())
        {
            Debug.Log("Command Queue is empty");
            return;
        }

        Debug.Log("Command Queue:");
        ICommand command = currentCommand == null ? new Command() : currentCommand;
        Debug.Log("Current Command: " + command.Name);

        foreach(ICommand c in localList)
        {
            string toPrint = $"{c.Name}, {c.Countdown}";
            Debug.Log(toPrint);
        }
    }

    public void UpdateCommand()
    {
        if (currentCommand != null)
        {
            currentCommand.UpdateCommand();

            if (currentCommand.IsFinished(true))
                currentCommand = null;
            else
                return;
        }
        else if (IsEmpty())
            return;
        else
        {
            ICommand commandInFront = commandList[0];
            commandList.RemoveAt(0);
            commandInFront.Execute(this);
            currentCommand = commandInFront;
        }

        foreach(ICommand command in commandList)
        {
            command.Countdown = Mathf.Max(0, command.Countdown - 1);
        }
    }
}
