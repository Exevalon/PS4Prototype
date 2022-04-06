using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler campHandleInput;
    public event EventHandler startHandleInput;
    public static event EventHandler combatEnter;

    public CombatScene combatScene;

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

        /*
        // We create our queue by calling Create and then Add
        // we add some mock events, and we call Print to see what happens
        CommandQueue commandQueue = new CommandQueue();
        commandQueue.Create();

        commandQueue.Add(new Command { Name = "Welcome to the Arena!" }, -1);
        commandQueue.Add(new Command { Name = "Take Turn Goblin" }, 5);
        commandQueue.Add(new Command { Name = "Take Turn Hero" }, 4);

        commandQueue.Print();
        */

        // Create a new combat scene, add enemies and party members, and do a test run
        List<Actor> party = new List<Actor>();
        List<Actor> enemies = new List<Actor>();
        Hero hero = new Hero();
        Hero heroine = new Hero() { ActorName = "Heroine", AttackPower = 5 };
        Gobblerin gobblerin = new Gobblerin();
        Gobblerin gobblerin1 = new Gobblerin() { ActorName = "Gobblerin 1"};

        party.Add(hero);
        party.Add(heroine);
        enemies.Add(gobblerin);
        enemies.Add(gobblerin1);

        combatScene = new CombatScene(party, enemies);
        Debug.Log($"Created {combatScene} object");
    }

    private void Update()
    {
        if (InputManager.Instance.GetInteractButton())
            HandleInput(campHandleInput);

        if (InputManager.Instance.GetStartButton())
            HandleInput(startHandleInput);

        combatScene.UpdateScene();
    }

    public static void HandleInput(EventHandler eventHandler)
    {
        EventHandler handler = eventHandler;
        GameManager manager = MonoBehaviour.FindObjectOfType<GameManager>();
        if (handler != null)
            handler(manager, EventArgs.Empty);
    }

    public static void GoToCombat()
    {
        HandleInput(combatEnter);
    }
}

public class Hero : Actor
{
    public Hero()
    {
        Init();
    }

    public void Init()
    {
        ActorName = "Hero";
        ActorSpeed = 3;
        AttackPower = 2;
        HP = 5;
        isPlayer = true;
    }
}

public class Gobblerin : Actor
{
    public Gobblerin()
    {
        Init();
    }

    public void Init()
    {
        ActorName = "Gobblerin";
        ActorSpeed = 2;
        AttackPower = 2;
        HP = 5;
        isPlayer = false;
    }
}