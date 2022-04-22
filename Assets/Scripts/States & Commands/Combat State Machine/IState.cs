using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void HandleInput();
    void OnEnter();
    void OnExit();
    void UpdateState();
}
