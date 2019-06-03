using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    [SerializeField]
    Defender defender;

    private TextMeshProUGUI CostText;

    private void Start()
    {
        DefenderCost();
    }

    private void DefenderCost()
    {
        CostText = GetComponentInChildren<TextMeshProUGUI>();
        if (CostText)
        {
            CostText.text = defender.GetStarCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var defenders = FindObjectsOfType<DefenderButton>();
        foreach (var newDefender in defenders)
        {
            newDefender.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defender);
    }
}
