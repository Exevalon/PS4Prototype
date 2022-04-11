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
        // Initialize stats
        ActorName = "Centaur";
        ActorSpeed = 2;
        AttackPower = 2;
        HP = 5;
        Size = "Medium";
        isPlayer = false;

        // Initialize model
        ModelView model = GameObject.Find("ModelView").GetComponent<ModelView>();
        model.Sprite.sprite = Resources.Load<Sprite>("Centaur");
        model.Sprite.sortingLayerName = "Enemy";
        model.Sprite.sortingOrder = 5;
        Model = model;
    }
}
