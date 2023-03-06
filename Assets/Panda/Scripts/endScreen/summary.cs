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
        customerServed.text = Customer.noOfCustomersServed.ToString();
        customerMissed.text = Customer.noOfCustomersMissed.ToString();

        if (PlayerPrefs.GetInt("currentLevel") == 5)
        {
            if (Inventory.PlayerScore >= pointsForEachLevel.level_1)
                winOrLose = true;
        }
        else
        {
            if (Inventory.PlayerScore >= pointsForEachLevel.level_2)
                winOrLose = true;
        }
        if (winOrLose)
        {
            if (PlayerPrefs.GetInt("currentLevel") < 6)
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
