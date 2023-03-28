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

    public GameObject[] lvlRating;
    int noOfStars = 0;
    public Sprite[] ratingStarTypes;

    public Text button;

    public bool winOrLose = false;
    public Animator Anim;

    [SerializeField] public GameObject startTransition;

    // Start is called before the first frame update
    void Start()
    {
        Anim.SetBool("Win", false);
        Anim.SetBool("Lose", false);
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
            Anim.SetBool("Win", true);
            if (currentLevel <= levelDB.maxLevel)
            {
                if (currentLevel == 0)
                {
                    //stars
                    noOfStars = 0;
                    for (int i = 0; i < levelDB.level1_Rating.Length; i++)
                    {
                        if (Inventory.PlayerScore >= levelDB.level1_Rating[i])
                        {
                            noOfStars += 1;
                        }
                    }
                    for (int i = 0; i < noOfStars; i++)
                    {
                        lvlRating[i].transform.GetComponent<Image>().sprite = ratingStarTypes[1];
                    }

                    //hs
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
                    //stars
                    noOfStars = 0;
                    for (int i = 0; i < levelDB.level2_Rating.Length; i++)
                    {
                        if (Inventory.PlayerScore >= levelDB.level2_Rating[i])
                        {
                            noOfStars += 1;
                        }
                    }
                    for (int i = 0; i < noOfStars; i++)
                    {
                        lvlRating[i].transform.GetComponent<Image>().sprite = ratingStarTypes[1];
                    }

                    //hs
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
                    //stars
                    noOfStars = 0;
                    for (int i = 0; i < levelDB.level3_Rating.Length; i++)
                    {
                        if (Inventory.PlayerScore >= levelDB.level3_Rating[i])
                        {
                            noOfStars += 1;
                        }
                    }
                    for (int i = 0; i < noOfStars; i++)
                    {
                        lvlRating[i].transform.GetComponent<Image>().sprite = ratingStarTypes[1];
                    }

                    //hs
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
                if (currentLevel < levelDB.maxLevel)
                {
                    PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);
                    
                }
                else
                {
                    PlayerPrefs.SetInt("currentLevel", 4);
                }
                
            }
            SoundManager.Instance.PlaySFX("SummaryWin");
            winLoseText.text = "YOU WIN!";
            button.text = "NEXT LEVEL";
            Anim.SetTrigger("Win");

        }
        else
        {
            Anim.SetBool("Lose", false);
            SoundManager.Instance.PlaySFX("SummaryLose");
            winLoseText.text = "YOU LOSE!";
            button.text = "TRY AGAIN";
            Anim.SetTrigger("Lose");
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
