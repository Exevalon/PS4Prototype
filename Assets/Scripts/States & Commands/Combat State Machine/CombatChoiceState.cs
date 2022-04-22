using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatChoiceState : MonoBehaviour, IState
{
    /* This state handles selection and updates it
     * It shows what commands are available to the player
     * While this state is active (or on the stack if I use that), the command queue is not updated
     */
    // Event Handlers
    private event EventHandler handleComd;
    private event EventHandler handleMacro;
    private event EventHandler handleRun;

    // Top Level Commands
    private State_Command stateCommand;
    private State_Macro stateMacro;
    private State_Run stateRun;

    // Enemy and Party list
    private List<Actor> partyList;
    private List<Actor> enemyList;

    // Top Level Command Box
    private GameObject commandBoxTop;
    private GameObject selectionBox;
    private GameObject commandObject;
    private GameObject selection;
    private SelectionOutline[] selectionOutline;

    // Selection Indicator inside Top Level Command Box
    private int selectionIndex = 0;
    private bool inputOff = true;
    private float inputTimer = 0f;

    private CombatState combatState;
    private GameObject combatUIObject;
    private GameObject combatUIPrefab;
    private Choices choice;
    private IState commandState;

    public enum Choices
    {
        Command,
        Macro,
        Run
    }

    public void CreateCombatChoiceState(List<Actor> party, List<Actor> enemy, CombatState state)
    {
        partyList = party;
        enemyList = enemy;
        combatState = state;

        stateCommand = new State_Command();
        stateMacro = new State_Macro();
        stateRun = new State_Run();

        handleComd += stateCommand.OnEnter;
        handleMacro += stateMacro.OnEnter;
        handleRun += stateRun.OnEnter;

        commandBoxTop = Resources.Load<GameObject>("CommandBoxUI_Top");
        selectionBox = Resources.Load<GameObject>("SelectionBox");

        combatUIPrefab = Resources.Load<GameObject>("CombatUI");
        combatUIObject = Instantiate(combatUIPrefab, combatState.transform);

        OnEnter();
    }

    public void CreateCombatChoiceUI()
    {
        commandObject = Instantiate(commandBoxTop, combatState.transform);
        selectionOutline = commandObject.GetComponentsInChildren<SelectionOutline>();
        
        selection = Instantiate(selectionBox, selectionOutline[0]._transform.position, Quaternion.identity, selectionOutline[0].transform);
    }

    /// <summary>
    /// Handle input from player
    /// </summary>
    public void HandleInput()
    {
        // This handles input for the top level command box
        // I'll need handling for the sub-level command box with the rest of the commands
        int input = Mathf.RoundToInt(InputManager.Instance.GetVerticalAxis());
        inputTimer += Time.deltaTime;

        if (input != 0 && inputOff)
        {
            inputOff = false;

            if (input > 0)
            {
                selectionIndex--;

                if (selectionIndex < 0)
                        selectionIndex = 2;
            }
            else
            {
                selectionIndex++;

                if (selectionIndex > 2)
                    selectionIndex = 0;
            }

            selection.transform.position = selectionOutline[selectionIndex].transform.position;
        }

        if(inputTimer > 0.4f)
        {
            inputTimer = 0;
            inputOff = true;
        }

        if(InputManager.Instance.GetInteractButton1())
        {
            switch(selectionIndex)
            {
                case 0:
                    choice = Choices.Command;
                    HandleInput(handleComd);
                    commandState = stateCommand;
                    HideCommandBox();
                    break;
                case 1:
                    choice = Choices.Macro;
                    HandleInput(handleMacro);
                    break;
                case 2:
                    choice = Choices.Run;
                    HandleInput(handleRun);
                    break;
            }
        }

        if(InputManager.Instance.GetInteractButton2())
        {
            // if we back out from the command UI, we return to the previous state, which is the top level command box UI
            // The command UI object should be destroyed
            // and the hidden command box UI should re-appear
        }
    }

    /// <summary>
    /// Handle input with an event
    /// </summary>
    /// <param name="eventHandler"></param>
    public void HandleInput(EventHandler eventHandler)
    {
        EventHandler handler = eventHandler;
        if (handler != null)
            handler(handler, EventArgs.Empty);
    }

    public void OnEnter()
    {
        // Need to make sure none of this runs twice if we happen to back out from the command UI to top level command
        // could use a boolean check or something
        combatUIObject.GetComponent<CombatUI>().CreatePlayerUIBoxes(partyList);
        CreateCombatChoiceUI();
    }

    public void OnExit()
    {

    }

    public void UpdateState()
    {
        if(!State_Command.isSubCommandActive)
            HandleInput();
        if(State_Command.isSubCommandActive)
            stateCommand.UpdateState();
    }

    /// <summary>
    /// Hides command box when an option is chosen
    /// </summary>
    private void HideCommandBox()
    {
        foreach(SpriteRenderer renderer in commandObject.GetComponentsInChildren<SpriteRenderer>())
        {
            renderer.enabled = false;
        }
    }
}
