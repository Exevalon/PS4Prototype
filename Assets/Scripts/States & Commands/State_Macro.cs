using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Macro : IState
{
    public void HandleInput()
    {

    }

    public void OnEnter() { }

    public void OnEnter(object sender, EventArgs e)
    {
        Debug.Log("Macro choice selected!");
    }

    public void OnExit()
    {
        // clean up its objects on exit
    }

    public void UpdateState()
    {

    }
}
