using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScene : SceneState
{
    private List<Actor> party;
    private List<Actor> enemies;
    private CommandQueue commandQueue = new CommandQueue();

    public CombatScene(List<Actor> party, List<Actor> enemies)
    {
        this.party = party;
        this.enemies = enemies;
        commandQueue.Create();

        AddTurns(party);
        AddTurns(enemies);
    }

    public void AddTurns(List<Actor> actorList)
    {
        foreach(Actor actor in actorList)
        {
            if(!commandQueue.ActorHasCommand(actor))
            {
                ICommand command = new Command_Turn(this, actor);
                int tp = command.TimePoints(commandQueue);
                commandQueue.Add(command, tp);
            }
        }
    }

    public override Actor GetTarget(Actor actor)
    {
        // needs to return a target list
        List<Actor> targetList = new List<Actor>();

        if (actor.IsPlayer(actor.isPlayer))
            targetList = enemies;
        else
            targetList = party;

        return targetList[Random.Range(0, targetList.Count)];
    }

    public override List<Actor> GetLivePartyActors()
    {
        List<Actor> liveList = new List<Actor>();

        foreach(Actor actor in party)
        {
            if(!actor.IsKOed())
                liveList.Add(actor);
        }

        return liveList;
    }

    public bool IsEnemyDefeated()
    {
        return enemies.Count == 0;
    }

    public override bool IsPartyDefeated()
    {
        foreach(Actor actor in party)
        {
            if(!actor.IsKOed())
                return false;
        }

        return true;
    }

    public override void OnDead(Actor target)
    {
        // Does cleanup
        if (target.IsPlayer(target.isPlayer))
            target.IsKO();
        else
        {
            for(int i = enemies.Count - 1; i >= 0; i--)
            {
                var enemy = enemies[i];
                if (target == enemy)
                    enemies.Remove(enemy);
            }
        }

        commandQueue.RemoveCommandsByActor(target);

        if (IsPartyDefeated())
            Debug.Log("Party is defeated...");
        else if (IsEnemyDefeated())
            Debug.Log("Enemies have been defeated! \n *queue victory jingle*");
    }

    public override void UpdateScene()
    {
        commandQueue.UpdateCommand();

        if (IsPartyDefeated() || IsEnemyDefeated())
            commandQueue.ClearCommandList();
        else
        {
            AddTurns(party);
            AddTurns(enemies);
        }
    }

    public override bool IsPartyMember(Actor actor)
    {
        foreach (Actor a in party)
        {
            if (actor == a)
                return true;
        }
        return false;
    }
}
