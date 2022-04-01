using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler campHandleInput;
    public event EventHandler startHandleInput;

    public CampMenu campMenu;
    public StartMenu startMenu;

    public static bool eventIsEnabled = false;

    private void Start()
    {
        campHandleInput += campMenu.HandleInput;
        startHandleInput += startMenu.HandleInput;
    }

    private void Update()
    {
        if (InputManager.Instance.GetInteractButton())
            HandleInput(campHandleInput);

        if (InputManager.Instance.GetStartButton())
            HandleInput(startHandleInput);
    }

    public void HandleInput(EventHandler eventHandler)
    {
        EventHandler handler = eventHandler;
        if (handler != null)
            handler(this, EventArgs.Empty);
    }
}
