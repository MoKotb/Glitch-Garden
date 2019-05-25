using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    public void SetSelectedDefender(Defender newDefender)
    {
        defender = newDefender;
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPosition)
    {
        int starCost = defender.GetStarCost();
        var StarDisplay = FindObjectOfType<StarDisplay>();
        if (StarDisplay.HaveEnoughStars(starCost))
        {
            SpawnDefender(gridPosition);
            StarDisplay.SpendStars(starCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        Vector2 rawWorldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 gridPositon = SnapToGrid(rawWorldPosition);
        return gridPositon;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);
        return new Vector2(newX,newY);
    }

    private void SpawnDefender(Vector2 roundedPosition)
    {
        if (defender)
        {
            Defender newDefender = Instantiate(defender, roundedPosition, Quaternion.identity);
        }
    }

}
