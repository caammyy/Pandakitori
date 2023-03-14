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
    public float cusServed, cusMissed, totPoints = 0f;
    public float growthRate = 1f;

    public Text winLoseText;

    public Text button;

    public bool winOrLose = false;

    [SerializeField] public GameObject startTransition;

    // Start is called before the first frame update
    void Start()
    {
        //transition
        startTransition.SetActive(true);
        Invoke("startTransitionFalse", 5f);


        totalPoints.text = totPoints.ToString();
        customerServed.text = cusServed.ToString();
        customerMissed.text = cusMissed.ToString();

        int currentLevel = PlayerPrefs.GetInt("currentLevel") - 5;
        Debug.Log(currentLevel);

        bgObject.transform.GetComponent<Image>().sprite = bg[currentLevel];

        if (Inventory.PlayerScore >= levelDB.levelScore[currentLevel])
        {
            winOrLose = true;
        }
        if (winOrLose == true)
        {
            if (currentLevel <= levelDB.maxLevel)
            {
                if (currentLevel == 0)
                {
                    if (PlayerPrefs.HasKey("Level1_HS"))
                    {
                        if (Inventory.PlayerScore > PlayerPrefs.GetInt("Level1_HS"))
                        {
                            PlayerPrefs.SetInt("Level1_HS", Inventory.PlayerScore);
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Level1_HS", Inventory.PlayerScore);
                    }
                }
                if (currentLevel == 1)
                {
                    if (PlayerPrefs.HasKey("Level2_HS"))
                    {
                        if (Inventory.PlayerScore > PlayerPrefs.GetInt("Level2_HS"))
                        {
                            PlayerPrefs.SetInt("Level2_HS", Inventory.PlayerScore);
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Level2_HS", Inventory.PlayerScore);
                    }
                }
                if (currentLevel == 2)
                {

                    if (PlayerPrefs.HasKey("Level3_HS"))
                    {
                        if (Inventory.PlayerScore > PlayerPrefs.GetInt("Level3_HS"))
                        {
                            PlayerPrefs.SetInt("Level3_HS", Inventory.PlayerScore);
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt("Level3_HS", Inventory.PlayerScore);
                    }
                    Debug.Log(PlayerPrefs.GetInt("Level3_HS").ToString());
                }
                if (PlayerPrefs.GetInt("currentLevel") == PlayerPrefs.GetInt("levelsunlocked") && currentLevel < levelDB.maxLevel)
                {
                    PlayerPrefs.SetInt("levelsunlocked", PlayerPrefs.GetInt("levelsunlocked") + 1);
                }
                else
                {
                    PlayerPrefs.SetInt("currentLevel", 3);
                }
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

    void FixedUpdate()
    {

        if (cusServed < Inventory.noOfCustomersServed)
        {
            cusServed += growthRate;
        }
        if (cusMissed < Inventory.noOfCustomersMissed)
        {
            cusMissed += growthRate;
        }
        if (totPoints < Inventory.PlayerScore)
        {
            totPoints += growthRate;
        }
        totalPoints.text = ((int)totPoints).ToString();
        customerServed.text = ((int)cusServed).ToString();
        customerMissed.text = ((int)cusMissed).ToString();

    }

    public void startTransitionFalse()
    {
        startTransition.SetActive(false);
    }

}
