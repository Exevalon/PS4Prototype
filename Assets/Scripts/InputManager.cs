using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public bool isAxisInUse = false;
    public bool isPressed = false;

    public float GetHorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetVerticalAxis()
    {
        return Input.GetAxis("Vertical");
    }

    public bool GetInteractButton()
    {
        return Input.GetButtonDown("Fire1");
    }
}
