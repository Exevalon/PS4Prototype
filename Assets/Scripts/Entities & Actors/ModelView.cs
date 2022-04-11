using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelView : MonoBehaviour
{
    public SpriteRenderer Sprite { get; set; }
    public Actor actor { get; set; }

    // will eventually need an animator controller

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Sprite = GetComponent<SpriteRenderer>();
    }
}
