using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class State_Run : IState
{
    public void HandleInput()
    {

    }

    public void OnEnter() { }

    public void OnEnter(object sender, EventArgs e)
    {
        Debug.Log("Running from combat!");
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
        OnExit();
    }

    public void OnExit()
    {
        // clean up its objects on exit
    }

    public void UpdateState()
    {

    }
}
