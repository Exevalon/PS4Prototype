using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Centaur : Actor
{
    public Enemy_Centaur()
    {
        Init();
    }

    public void Init()
    {
        ActorName = "Centaur";
        ActorSpeed = 2;
        AttackPower = 2;
        HP = 5;
        Size = "Medium";
        isPlayer = false;
        Sprite = Resources.Load<Sprite>("Centaur");
        sortingLayer = "Enemy";
        order = 5;
    }
}
