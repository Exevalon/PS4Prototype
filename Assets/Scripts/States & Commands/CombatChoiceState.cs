using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatChoiceState : MonoBehaviour
{
    /* This state handles selection and updates it
     * It shows what commands are available to the player
     * While this state is active (or on the stack if I use that), the command queue is not updated
     */
    GameObject commandBoxTop;
    GameObject selectionBox;

    private void Awake()
    {
        commandBoxTop = Resources.Load<GameObject>("CommandBoxUI_Top");
        selectionBox = Resources.Load<GameObject>("SelectionBox");
    }
    public void CreateCombatChoiceUI()
    {
        GameObject commandObject = Instantiate(commandBoxTop, this.transform);
        Transform[] selectionOutline = commandObject.GetComponentsInChildren<Transform>();
        
        var selection = Instantiate(selectionBox, selectionOutline[2].transform.position, Quaternion.identity, selectionOutline[0].transform);
    }
}
