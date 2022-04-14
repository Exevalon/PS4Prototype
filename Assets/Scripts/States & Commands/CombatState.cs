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
    [SerializeField]
    private GameObject CombatUIPrefab;
    [SerializeField]
    private GameObject CombatChoiceState;

    public static bool isCombatStarted = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void EnterCombat(object sender, EventArgs e)
    {
        OnEnter();
    }

    public void HandleInput() { }

    public void OnEnter()
    {
        GameManager.eventIsEnabled = true;
        SceneManager.LoadScene("Combat", LoadSceneMode.Single);

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

        HandleUI();

        isCombatStarted = true;
    }

    public void OnExit()
    {
        isCombatStarted = false;
        GameManager.eventIsEnabled = false;
    }

    public void UpdateState()
    {
        combatScene.UpdateScene();

        foreach(Actor actor in partyList)
        {
            actor.UpdateActorState(actor.state);
        }

        foreach(Actor actor in enemyList)
        {
            actor.UpdateActorState(actor.state);
        }
    }

    public void CreateCharacters(List<Actor> party)
    {
        // Create the characters for combat and set their states
    }

    public void HandleUI()
    {
        // This creates the UI when combat starts
        // I need to have something that will update it as combat happens

        GameObject combatUIObject = Instantiate(CombatUIPrefab, this.transform);
        GameObject combatChoiceObject = Instantiate(CombatChoiceState, this.transform);
        CombatChoiceState combatChoiceState = combatChoiceObject.GetComponent<CombatChoiceState>();
        combatChoiceState.CreateCombatChoiceUI();
        CombatUI combatUI = combatUIObject.GetComponent<CombatUI>();
        combatUI.CreateUI();
        List<GameObject> UIBoxList = combatUI.ReturnUIBoxList();

        foreach(GameObject go in UIBoxList)
        {
            //get each textmesh from each UI box and set it for each party character's info
            TextMeshProUGUI[] textmeshes = go.GetComponentsInChildren<TextMeshProUGUI>();

            foreach (Actor actor in partyList)
            {
                textmeshes[0].text = actor.ActorName;
                textmeshes[1].text = actor.state.ToString();
                textmeshes[2].text = actor.HP.ToString();
                textmeshes[3].text = actor.TP.ToString();
            }
        }
    }
}
