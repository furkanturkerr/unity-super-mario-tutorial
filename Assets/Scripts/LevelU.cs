using TMPro;
using UnityEngine;

public class LevelU : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI levelText;

    public int currentLevel = 1;

    void Start()
    {
        UpdateLevelText();
    }

    void UpdateLevelText()
    {
        int level = GameManager.Instance.currentLevel;
        levelText.text = "Seviye: " + level.ToString();
    }
}
