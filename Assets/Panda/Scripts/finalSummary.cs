using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class finalSummary : MonoBehaviour
{
    public Text lvl1Score;
    public Text lvl2Score;
    public Text lvl3Score;

    public GameObject[] lvl1Rating, lvl2Rating, lvl3Rating;

    public Sprite[] ratingStarTypes;

    int noOfStars = 0;

    [SerializeField] public GameObject startTransition;
    [SerializeField] public GameObject endTransition;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic("Background");

        startTransition.SetActive(true);
        Invoke("startTransitionFalse", 5f);
        SetLVl1();
        SetLVl2();
        SetLVl3();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetLVl1()
    {
        lvl1Score.text = PlayerPrefs.GetInt("Level1_HS").ToString();

        noOfStars = 0;
        for (int i = 0; i < levelDB.level1_Rating.Length; i++) { 
            if (PlayerPrefs.GetInt("Level1_HS") >= levelDB.level1_Rating[i])
            {
                noOfStars += 1;
            }
        }
        for(int i = 0; i < noOfStars; i++)
        {
            lvl1Rating[i].transform.GetComponent<Image>().sprite = ratingStarTypes[1];
        }
    }
    public void SetLVl2()
    {
        lvl2Score.text = PlayerPrefs.GetInt("Level2_HS").ToString();

        noOfStars = 0;
        for (int i = 0; i < levelDB.level2_Rating.Length; i++)
        {
            if (PlayerPrefs.GetInt("Level2_HS") >= levelDB.level2_Rating[i])
            {
                noOfStars += 1;
            }
        }
        for (int i = 0; i < noOfStars; i++)
        {
            lvl2Rating[i].transform.GetComponent<Image>().sprite = ratingStarTypes[1];
        }
    }
    public void SetLVl3()
    {
        lvl3Score.text = PlayerPrefs.GetInt("Level3_HS").ToString();

        noOfStars = 0;
        for (int i = 0; i < levelDB.level3_Rating.Length; i++)
        {
            if (PlayerPrefs.GetInt("Level3_HS") >= levelDB.level3_Rating[i])
            {
                noOfStars += 1;
            }
        }
        for (int i = 0; i < noOfStars; i++)
        {
            lvl3Rating[i].transform.GetComponent<Image>().sprite = ratingStarTypes[1];
        }
    }
    public void Home()
    {
        endTransition.SetActive(true);
        Invoke("homeScene", 1.5f);
    }
    public void startTransitionFalse()
    {
        startTransition.SetActive(false);
    }
    public void homeScene()
    {
        SceneManager.LoadScene(0);
    }
}
