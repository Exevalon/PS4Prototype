using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CombatState : MonoBehaviour, IState
{
    private CombatScene combatScene;
    private List<Actor> partyList;
    private List<Actor> enemyList;
    //[SerializeField]
    //private CombatChoiceState combatChoiceState;

    public static bool isCombatStarted = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void EnterCombat(object sender, EventArgs e)
    {
        GameManager.eventIsEnabled = true;
        SceneManager.LoadScene("Combat", LoadSceneMode.Single);
        OnEnter();
    }

    public void HandleInput() { }

    public void OnEnter()
    {
        // Create a new combat scene, add enemies and party members, and do a test run
        List<Actor> party = new List<Actor>();
        List<Actor> enemies = new List<Actor>();
        Vector2[] posList = Layout_Player.GetLayoutParty();

        // index check will eventually be based off the party count
        for (int i = 0; i < 5; i++)
        {
            party.Add(new PC_Alys());
            party[i].state = ActorStates.actorStates.standby;
            var viewModel = Instantiate(party[i].Model, new Vector2(posList[i].x, posList[i].y), Quaternion.identity);
            viewModel.name = party[i].ActorName;
        }

        posList = Layout_Enemy.GetLayout("Medium");

        // index check will eventually be based off the enemy count
        for (int i = 0; i < 4; i++)
        {
            enemies.Add(new Enemy_Centaur());
            enemies[i].state = ActorStates.actorStates.standby;
            var viewModel = Instantiate(enemies[i].Model, new Vector2(posList[i].x, posList[i].y), Quaternion.identity);
            viewModel.name = enemies[i].ActorName;
        }

        combatScene = new CombatScene(party, enemies);
        partyList = party;
        enemyList = enemies;
        Debug.Log($"Created {combatScene} object");

        //combatChoiceState.CreateCombatChoiceState(party, enemies, this);

        isCombatStarted = true;
    }

    public void OnExit()
    {
        //combatChoiceState.OnExit();
        isCombatStarted = false;
        GameManager.eventIsEnabled = false;
    }

    public void UpdateState()
    {
        combatScene.UpdateScene();
        //combatChoiceState.UpdateState();
        /*
        foreach(Actor actor in partyList)
        {
            actor.UpdateActorState(actor.state);
        }

        foreach(Actor actor in enemyList)
        {
            actor.UpdateActorState(actor.state);
        }
        */
    }

    public void CreateCharacters(List<Actor> group)
    {
        // Create the characters for combat and set their states
        // This will include player characters and enemies
        // I will need to write an abstract function
    }
}
