using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Layout_Player
{
    private static Vector2[] layoutParty = {
        new Vector2(0, -0.25f),
        new Vector2(0.5f, -0.25f),
        new Vector2(-0.5f, -0.25f),
        new Vector2(1f, -0.25f),
        new Vector2(-1f, -0.25f)
    };

    public static Vector2[] GetLayoutParty()
    {
        return layoutParty;
    }
}
