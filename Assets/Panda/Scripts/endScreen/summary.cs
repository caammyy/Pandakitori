using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class summary : MonoBehaviour
{
    public Text customerServed;
    public Text customerMissed;
    public Text totalPoints;
    public Text reputation;

    public Text winLoseText;

    public Text button;

    public bool winOrLose = false;
    // Start is called before the first frame update
    void Start()
    {
        totalPoints.text = Inventory.PlayerScore.ToString();
        if (Inventory.PlayerScore >= pointsForEachLevel.level_1)
        {
            Debug.LogWarning("Summary");
            Debug.LogWarning(PlayerPrefs.GetInt("levelsunlocked"));
            Debug.LogWarning(PlayerPrefs.GetInt("currentLevel"));
            winOrLose = true;
            if (PlayerPrefs.GetInt("currentLevel") == PlayerPrefs.GetInt("levelsunlocked"))
            {
                PlayerPrefs.SetInt("levelsunlocked", PlayerPrefs.GetInt("levelsunlocked") + 1);
            }
            PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);
        }
        if (winOrLose)
        {
            winLoseText.text = "YOU WIN!";
            button.text = "NEXT LEVEL";
        }
        else
        {
            winLoseText.text = "YOU LOSE!";
            button.text = "TRY AGAIN";
        }
    }
}
