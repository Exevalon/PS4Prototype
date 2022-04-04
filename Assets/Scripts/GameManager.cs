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

        // We create our queue by calling Create and then Add
        // we add some mock events, and we call Print to see what happens
        CommandQueue commandQueue = new CommandQueue();
        commandQueue.Create();

        commandQueue.Add(new Command { Name = "Welcome to the Arena!" }, -1);
        commandQueue.Add(new Command { Name = "Take Turn Goblin" }, 5);
        commandQueue.Add(new Command { Name = "Take Turn Hero" }, 4);

        commandQueue.Print();
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
