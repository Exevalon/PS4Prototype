using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler campHandleInput;
    public event EventHandler startHandleInput;
    public static event EventHandler combatEnter;

    public CampMenu campMenu;
    public StartMenu startMenu;
    public CombatState combatState;

    // used to check if an event or state is active or not
    public static bool eventIsEnabled = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        campHandleInput += campMenu.HandleInput;
        startHandleInput += startMenu.HandleInput;
        combatEnter += combatState.EnterCombat;
    }

    private void Update()
    {
        if (InputManager.Instance.GetInteractButton())
            HandleInput(campHandleInput);

        if (InputManager.Instance.GetStartButton())
            HandleInput(startHandleInput);

        if (CombatState.isCombatStarted)
            combatState.UpdateState();

        // test tool
        if(Input.GetKeyDown(KeyCode.G))
            GoToCombat();
    }

    public void HandleInput(EventHandler eventHandler)
    {
        EventHandler handler = eventHandler;
        if (handler != null)
            handler(handler, EventArgs.Empty);
    }

    public void GoToCombat()
    {
        HandleInput(combatEnter);
    }
}