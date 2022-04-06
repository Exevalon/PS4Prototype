using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatState : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void EnterCombat(object sender, EventArgs e)
    {
        GameManager.eventIsEnabled = true;
        SceneManager.LoadScene("Combat", LoadSceneMode.Single);
    }
}
