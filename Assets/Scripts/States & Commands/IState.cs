using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public abstract void HandleInput();
    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void UpdateState();
}
