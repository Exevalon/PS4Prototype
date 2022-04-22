using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Command : IState
{
    private GameObject commandUIObj;
    private GameObject commandArrow;

    private Transform[] commands;

    public static bool isSubCommandActive = false;

    // Selection Indicator inside Top Level Command Box
    private int selectionIndex = 0;
    private bool inputOff = true;
    private float inputTimer = 0f;

    private enum Choices
    {
        attack,
        techniques,
        skills,
        items,
        guard
    }

    private Choices choice;

    public void HandleInput()
    {
        int input = Mathf.RoundToInt(InputManager.Instance.GetHorizontalAxis());
        inputTimer += Time.deltaTime;

        if (input != 0 && inputOff)
        {
            inputOff = false;

            if (input < 0)
            {
                selectionIndex--;

                if (selectionIndex < 1)
                    selectionIndex = 5;
            }
            else
            {
                selectionIndex++;

                if (selectionIndex > 5)
                    selectionIndex = 1;
            }

            Vector2 arrowPos = new Vector2(commands[selectionIndex].transform.position.x, commands[selectionIndex].transform.position.y + .25f);
            commandArrow.transform.position = arrowPos;
        }

        if (inputTimer > 0.4f)
        {
            inputTimer = 0;
            inputOff = true;
        }

        if (InputManager.Instance.GetInteractButton1())
        {
            switch (selectionIndex)
            {
                case 1:
                    choice = Choices.attack;
                    // choose target
                    break;
                case 2:
                    choice = Choices.techniques;
                    // choose tech from list
                    // choose targets if necessary
                    break;
                case 3:
                    choice = Choices.skills;
                    // choose skill from list
                    // choose targets if necessary
                    break;
                case 4:
                    choice = Choices.items;
                    // choose items from list
                    // choose targets for items if necessary
                    break;
                case 5:
                    choice = Choices.guard;
                    // increase defense
                    break;
            }
        }
    }

    public void OnEnter() { }

    public void OnEnter(object sender, EventArgs e)
    {
        Debug.Log("Command choice selected!");
        isSubCommandActive = true;

        // create command UI
        var commandPrefab = Resources.Load<GameObject>("Command_UI");
        var arrowPrefab = Resources.Load<GameObject>("SelectionArrow");

        GameObject combatState = GameObject.Find("CombatState");

        // We need to instantiate the UI to either the left or right of a given character depending on which position they are in
        commandUIObj = GameObject.Instantiate(commandPrefab, combatState.transform);
        commands = commandUIObj.GetComponentsInChildren<Transform>();

        Vector2 arrowPos = new Vector2(commands[1].transform.position.x, commands[1].transform.position.y + .25f);
        commandArrow = GameObject.Instantiate(arrowPrefab, arrowPos, Quaternion.identity, commandUIObj.transform);
    }

    public void OnExit()
    {
        // need to clean up its objects on exit
        isSubCommandActive = false;
        GameObject.Destroy(commandUIObj);
        GameObject.Destroy(commandArrow);
    }

    public void UpdateState()
    {
        HandleInput();
    }
}
