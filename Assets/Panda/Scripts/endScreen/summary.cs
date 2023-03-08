using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class summary : MonoBehaviour
{
    public Text customerServed;
    public Text customerMissed;
    public Text totalPoints;

    public Text winLoseText;

    public Text button;

    public bool winOrLose = false;
    // Start is called before the first frame update
    void Start()
    {
        totalPoints.text = Inventory.PlayerScore.ToString();
        customerServed.text = Inventory.noOfCustomersServed.ToString();
        customerMissed.text = Inventory.noOfCustomersMissed.ToString();

        int currentLevel = PlayerPrefs.GetInt("currentLevel") - 5;

        if (Inventory.PlayerScore >= levelDB.levelScore[currentLevel])
        {
            winOrLose = true;
        }
        if (winOrLose)
        {
            if (currentLevel != levelDB.maxLevel)
            {
                if (PlayerPrefs.GetInt("currentLevel") == PlayerPrefs.GetInt("levelsunlocked"))
                {
                    PlayerPrefs.SetInt("levelsunlocked", PlayerPrefs.GetInt("levelsunlocked") + 1);
                }
                PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);
            }
            else
            {
                PlayerPrefs.SetInt("currentLevel", 4);
            }
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
