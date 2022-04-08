using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatState : MonoBehaviour, IState
{
    private CombatScene combatScene;
    [SerializeField]
    private ModelView modelPlayer;
    [SerializeField]
    private ModelView modelEnemy;

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
        List<ModelView> modelsParty = new List<ModelView>();
        List<ModelView> modelsEnemies = new List<ModelView>();
        List<Actor> party = new List<Actor>();
        List<Actor> enemies = new List<Actor>();

        for(int i = 0; i < 5; i++)
        {
            modelPlayer = Instantiate(modelPlayer);
            modelPlayer.actor = new PC_Alys();
            modelPlayer.name = modelPlayer.actor.ActorName;
            modelsParty.Add(modelPlayer);
            party.Add(modelsParty[i].actor);
        }

        Vector2[] posList = Layout_Player.GetLayoutParty();
        // Gonna use this to index through my party list
        int index = 0;

        foreach (Vector2 pos in posList)
        {
            modelsParty[index].transform.position = pos;
            index++;
        }

        for(int i = 0; i < 4; i++)
        {
            modelEnemy = Instantiate(modelEnemy);
            modelEnemy.actor = new Enemy_Centaur();
            modelEnemy.name = modelEnemy.actor.ActorName;
            modelsEnemies.Add(modelEnemy);
            enemies.Add(modelsEnemies[i].actor);
        }

        posList = Layout_Enemy.GetLayout("Medium");
        index = 0;

        foreach(Vector2 pos in posList)
        {
            modelsEnemies[index].transform.position = pos;
            index++;
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
