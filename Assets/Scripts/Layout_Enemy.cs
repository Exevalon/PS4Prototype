using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Layout_Enemy
{
    // Five positions for small enemies
    private static Vector2[] layoutSmall = {
        new Vector2(0, 0.1f),
        new Vector2(0.6f, 0.1f),
        new Vector2(1.2f, 0.1f),
        new Vector2(-0.6f, 0.1f),
        new Vector2(-1.2f, 0.1f)
    };

    // Four positions for medium enemies
    private static Vector2[] layoutMedium = {
        new Vector2(0.4f, 0.25f),
        new Vector2(1.15f, 0.25f),
        new Vector2(-0.4f, 0.25f),
        new Vector2(-1.15f, 0.251f)
    };

    // Three positions for large enemies
    private static Vector2[] layoutLarge = {
        new Vector2(0, 0.25f),
        new Vector2(1f, 0.25f),
        new Vector2(-1f, 0.25f)
    };

    // One position for extra large enemies
    private static Vector2[] layoutExtraLarge = { new Vector2(0, 0.3f) };

    static public Vector2[] GetLayout(string size)
    {
        switch (size)
        {
            case "Small":
                return layoutSmall;
            case "Medium":
                return layoutMedium;
            case "Large":
                return layoutLarge;
            case "Extra":
                return layoutExtraLarge;
            default:
                return layoutSmall;
        }
    }
}
