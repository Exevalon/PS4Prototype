using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Alys : Actor
{
    public PC_Alys()
    {
        Init();
    }

    public void Init()
    {
        ActorName = "Alys";
        ActorSpeed = 3;
        AttackPower = 2;
        DefensePower = 3;
        HP = 5;
        isPlayer = true;
        Sprite = Resources.Load<Sprite>("Alys");
        sortingLayer = "Player";
        order = 1;
    }
}
