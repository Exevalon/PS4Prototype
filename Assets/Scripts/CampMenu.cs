using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampMenu : MonoBehaviour
{
    public void HandleInput(object sender, EventArgs e)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            Debug.Log("Opening Camp Menu!");
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("Closing Camp Menu!");
        }
    }
}
