using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    public abstract GameObject Source { get; set; }
    public abstract GameObject Target { get; set; }
    public abstract void HandleInput();
    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract bool IsUsable();
}
