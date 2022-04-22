using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatUI : MonoBehaviour
{
    public List<GameObject> charUIBoxes;
    private List<Vector2> UIBoxPositions = new List<Vector2>()
    {
        new Vector2(0, -68),
        new Vector2(-50,-68),
        new Vector2(50,-68),
        new Vector2(-100,-68),
        new Vector2(100,-68)
    };

    private string nameText = "";
    private string actionText = "";
    private string hpText = "0";
    private string tpText = "0";

    private CombatState combatState;

    public string Name 
    { 
        get { return nameText; }
        set { nameText = value; }
    }
    public string Action
    {
        get { return actionText; }
        set { actionText = value; }
    }
    public string HP
    {
        get { return hpText; }
        set { hpText = value; }
    }
    public string TP
    {
        get { return tpText; }
        set { tpText = value; }
    }
    
    /// <summary>
    /// Helper method that returns the character UI boxes
    /// </summary>
    /// <returns></returns>
    public List<GameObject> ReturnUIBoxList()
    {
        return charUIBoxes;
    }

    /// <summary>
    /// Creates the UI Boxes for the Party
    /// </summary>
    public void CreatePlayerUIBoxes(List<Actor> party)
    {
        combatState = GameObject.Find("CombatState").GetComponent<CombatState>();
        List<GameObject> UIBoxList = ReturnUIBoxList();

        for (int i = 0; i < UIBoxPositions.Count; i++)
        {
            Vector2 pos = UIBoxPositions[i];
            charUIBoxes.Add(Instantiate(charUIBoxes[0], this.transform));
            charUIBoxes[i].GetComponent<RectTransform>().anchoredPosition = pos;
        }

        foreach (GameObject go in UIBoxList)
        {
            //get each textmesh from each UI box and set it for each party character's info
            TextMeshProUGUI[] textmeshes = go.GetComponentsInChildren<TextMeshProUGUI>();

            foreach (Actor actor in party)
            {
                textmeshes[0].text = actor.ActorName;
                textmeshes[1].text = actor.state.ToString();
                textmeshes[2].text = actor.HP.ToString();
                textmeshes[3].text = actor.TP.ToString();
            }
        }
    }
}
