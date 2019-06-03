using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField]
    float baseLives = 5f;
    [SerializeField]
    int damage = 1;

    TextMeshProUGUI livesText;
    float lives;

    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        if (lives <= 0)
        {
            lives = 1;
        }
        livesText = GetComponent<TextMeshProUGUI>();
        if (livesText)
        {
            UpdateDisplay();
        }

    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public float GetLives()
    {
        return lives;
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
