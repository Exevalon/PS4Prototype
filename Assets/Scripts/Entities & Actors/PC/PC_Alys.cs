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
        // Initialize stats
        ActorName = "Alys";
        ActorSpeed = 3;
        AttackPower = 2;
        DefensePower = 3;
        HP = 5;
        isPlayer = true;

        // Initialize model
        ModelView model = GameObject.Find("ModelView").GetComponent<ModelView>();
        model.Sprite.sprite = Resources.Load<Sprite>("Alys");
        model.Sprite.sortingLayerName = "Player";
        model.Sprite.sortingOrder = 1;
        Model = model;
    }
}
