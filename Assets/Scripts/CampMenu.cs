using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampMenu : MonoBehaviour
{
    /* Camp Menu will be the place to check the player's
     * inventory, stats, equipment, set character order,
     * set macro/automatic commands, use techs/skills,
     * and even talk with your characters.
     * 
     * Camp Menu should be able to access a list of options
     * where each option can be walked through and selected with
     * a corresponding indicator of the currently selected option.
     * Some options have a sub-option, so Camp Menu should be
     * able to access that sub-list as well.
     * 
     * If you're in one option, then you can't be in another at
     * the same time, even though some options have sub-options.
     * This seems to indicate a need for a state machine and a
     * series of states all held in a list.
     */

    public void HandleInput(object sender, EventArgs e)
    {
        //If in overworld, open up
        if (!gameObject.activeSelf && !GameManager.eventIsEnabled)
        {
            gameObject.SetActive(true);
            GameManager.eventIsEnabled = true;
            Debug.Log("Opening Camp Menu!");
        }
        else if(GameManager.eventIsEnabled)
        {
            gameObject.SetActive(false);
            GameManager.eventIsEnabled = false;
            Debug.Log("Closing Camp Menu!");
        }
    }
}
