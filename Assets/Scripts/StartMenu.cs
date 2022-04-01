using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    /* Start Menu will access the states necessary to
     * change message and battle speed as well as
     * save the game
     */

    public void HandleInput(object sender, EventArgs e)
    {
        //If in overworld, open up
        if (!gameObject.activeSelf && !GameManager.eventIsEnabled)
        {
            gameObject.SetActive(true);
            GameManager.eventIsEnabled = true;
            Debug.Log("Opening Start Menu.");
        }
        else if (GameManager.eventIsEnabled)
        {
            gameObject.SetActive(false);
            GameManager.eventIsEnabled = false;
            Debug.Log("Closing Start Menu.");
        }
    }
}
