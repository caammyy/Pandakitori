using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text LevelTimeRemaining;
    public Image OrderSlot1;
    public Image OrderSlot2;
    public Image OrderSlot3;
    public Sprite Shrimp;
    public Sprite VegMeat;
    public Sprite Egg;
    public Sprite Blank;
    // public bool Countdown;
    // public bool StopCount;
    string inventory;
    static public int[] InventorySlots;
    public Image Star1;
    public Image Star2;
    public Image Star3;
    public Sprite Star;
    public Sprite GoldStar;
    bool PlayShimmer1;
    bool PlayShimmer2;
    bool PlayShimmer3;

    [SerializeField] public GameObject startTransition;

    void GetInventory()
    {
        InventorySlots = Inventory.InventorySlots;
        int count = 0;
        foreach (int a in InventorySlots)
        {
            count++;
        }
        for (int i = 0; i < count; i++)
        {
            if (InventorySlots[i] == 1)
            {
                if (i == 0)
                {
                    OrderSlot1.sprite = Shrimp;
                }
                else if (i == 1)
                {
                    OrderSlot2.sprite = Shrimp;
                }
                else if (i == 2)
                {
                    OrderSlot3.sprite = Shrimp;
                }
            }
            if (InventorySlots[i] == 2)
            {
                if (i == 0)
                {
                    OrderSlot1.sprite = VegMeat;
                }
                else if (i == 1)
                {
                    OrderSlot2.sprite = VegMeat;
                }
                else if (i == 2)
                {
                    OrderSlot3.sprite = VegMeat;
                }
            }
            if (InventorySlots[i] == 3)
            {
                if (i == 0)
                {
                    OrderSlot1.sprite = Egg;
                }
                else if (i == 1)
                {
                    OrderSlot2.sprite = Egg;
                }
                else if (i == 2)
                {
                    OrderSlot3.sprite = Egg;
                }
            }
            if (InventorySlots[i] == 0)
            {
                if (i == 0)
                {
                    OrderSlot1.sprite = Blank;
                }
                else if (i == 1)
                {
                    OrderSlot2.sprite = Blank;
                }
                else if (i == 2)
                {
                    OrderSlot3.sprite = Blank;
                }
            }
        }

        for (int i = 0; i < 3; i++)
        {
            inventory = string.Join("", Inventory.InventorySlots);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Star1.sprite = Star;
        Star2.sprite = Star;
        Star3.sprite = Star;
        // StopCount = false;
        // Countdown = false;
        PlayShimmer1 = false;
        PlayShimmer2 = false;
        PlayShimmer3 = false;
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            startTransition.SetActive(true);
            Invoke("startTransitionFalse", 5f);
            SoundManager.Instance.PlayMusic("Forest");
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            startTransition.SetActive(true);
            Invoke("startTransitionFalse", 5f);
            SoundManager.Instance.PlayMusic("FineDIning");
        }
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            startTransition.SetActive(true);
            Invoke("startTransitionFalse", 5f);
            SoundManager.Instance.PlayMusic("City");
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetInventory();
        ScoreText.text = Inventory.PlayerScore.ToString();
        LevelTimeRemaining.text = ((int)Timer.Level_Time_Remaining).ToString();

        // if ((int)Timer.Level_Time_Remaining < 30 && StopCount == false) {
        //         Countdown = true;
        // }
        // if (Countdown) {
        //     SoundManager.Instance.PlaySFX("Last30Sec");
        //     StopCount = true;
        //     Countdown = false;
        // }

        if (Inventory.PlayerScore >= 5)
        {
            Star1.sprite = GoldStar;
            if (PlayShimmer1 == false)
            {
                SoundManager.Instance.PlaySFX("GoldShimmer");
                PlayShimmer1 = true;
            }
        }
        if (Inventory.PlayerScore >= 10)
        {
            Star2.sprite = GoldStar;
            if (PlayShimmer2 == false)
            {
                SoundManager.Instance.PlaySFX("GoldShimmer");
                PlayShimmer2 = true;
            }
        }
        if (Inventory.PlayerScore >= 15)
        {
            Star3.sprite = GoldStar;
            if (PlayShimmer3 == false)
            {
                SoundManager.Instance.PlaySFX("GoldShimmer");
                PlayShimmer3 = true;
            }
        }
    }

    public void startTransitionFalse()
    {
        startTransition.SetActive(false);
    }
}
