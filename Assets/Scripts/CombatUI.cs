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
    
    public List<GameObject> ReturnUIBoxList()
    {
        return charUIBoxes;
    }

    public void CreateUI()
    {
        for (int i = 0; i < UIBoxPositions.Count; i++)
        {
            Vector2 pos = UIBoxPositions[i];
            charUIBoxes.Add(Instantiate(charUIBoxes[0], this.transform));
            charUIBoxes[i].GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }
}
