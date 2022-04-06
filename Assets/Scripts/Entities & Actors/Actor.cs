using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// May have this inherit from monobehaviour
public class Actor
{
    public bool isPlayer { get; set; }
    public string ActorName { get; set; }
    public int ActorSpeed { get; set; }
    public int HP { get; set; }
    public int AttackPower { get; set; }

    public bool IsKOed()
    {
        return HP <= 0;
    }

    public void IsKO()
    {
        //do something on death
        Debug.Log("Dead");
    }

    public bool IsPlayer(bool isPlayer)
    {
        this.isPlayer = isPlayer;

        return this.isPlayer;
    }
}
