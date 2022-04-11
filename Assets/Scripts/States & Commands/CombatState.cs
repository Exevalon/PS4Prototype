using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatState : MonoBehaviour, IState
{
    private CombatScene combatScene;
    //[SerializeField]
    //private ModelView modelPlayer;
    //[SerializeField]
    //private ModelView modelEnemy;

    public static bool isCombatStarted = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void EnterCombat(object sender, EventArgs e)
    {
        OnEnter();
    }

    public void HandleInput()
    {

    }

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
            var viewModel = Instantiate(party[i].Model);
            viewModel.name = party[i].ActorName;
            viewModel.transform.position = posList[i];
        }

        posList = Layout_Enemy.GetLayout("Medium");

        // index check will eventually be based off the enemy count
        for (int i = 0; i < 4; i++)
        {
            enemies.Add(new Enemy_Centaur());
            var viewModel = Instantiate(enemies[i].Model);
            viewModel.name = enemies[i].ActorName;
            viewModel.transform.position = posList[i];
        }

        combatScene = new CombatScene(party, enemies);
        Debug.Log($"Created {combatScene} object");

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
    }
}
