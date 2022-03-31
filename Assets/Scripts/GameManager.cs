using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler handleInput;

    public CampMenu campMenu;

    private void Start()
    {
        handleInput += campMenu.HandleInput;
    }

    private void Update()
    {
        // If we're in the overworld open the camp menu
        if (InputManager.Instance.GetInteractButton())
            HandleInput();
    }

    public void HandleInput()
    {
        EventHandler handler = handleInput;
        if (handler != null)
            handler(this, EventArgs.Empty);
    }
}
