using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    public abstract int Countdown { get; set; }
    public abstract string Name { get; set; }
    public abstract string Owner { get; set;}
    public abstract void Execute();
    public abstract void UpdateEvent();
    public abstract bool IsFinished();
}
