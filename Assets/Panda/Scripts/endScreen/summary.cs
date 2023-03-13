using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class summary : MonoBehaviour
{
    public Sprite[] bg;
    public GameObject bgObject;

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

        bgObject.transform.GetComponent<Image>().sprite = bg[currentLevel];

        Debug.LogWarning(Inventory.PlayerScore);
        Debug.LogWarning(levelDB.levelScore[currentLevel]);
        if (Inventory.PlayerScore >= levelDB.levelScore[currentLevel])
        {
            winOrLose = true;
            Debug.LogWarning(winOrLose);
        }
        if (winOrLose == true)
        {
            if (currentLevel != levelDB.maxLevel)
            {
                if (PlayerPrefs.GetInt("currentLevel") == PlayerPrefs.GetInt("levelsunlocked"))
                {
                    Debug.LogWarning(PlayerPrefs.GetInt("levelsunlocked"));
                    PlayerPrefs.SetInt("levelsunlocked", PlayerPrefs.GetInt("levelsunlocked") + 1);
                    Debug.LogWarning(PlayerPrefs.GetInt("levelsunlocked"));
                }
                PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);
            }
            else
            {
                PlayerPrefs.SetInt("currentLevel", 4);
            }
            SoundManager.Instance.PlaySFX("SummaryWin");
            winLoseText.text = "YOU WIN!";
            button.text = "NEXT LEVEL";
        }
        else
        {
            SoundManager.Instance.PlaySFX("SummaryLose");
            winLoseText.text = "YOU LOSE!";
            button.text = "TRY AGAIN";
        }
    }
}
