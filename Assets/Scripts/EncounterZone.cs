using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterZone : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Alys")
            Debug.Log("Entering Encounter Zone");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Alys")
            Debug.Log("Exiting Encounter Zone");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Alys")
        {
            int chance = Random.Range(0, 100);

            if (chance == 1)
            {
                gameManager.GoToCombat();
            }
        }
    }
}
