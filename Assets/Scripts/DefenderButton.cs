using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField]
    Defender defender;
    
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
