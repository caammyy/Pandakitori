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
    string inventory;
    static public int[] InventorySlots;
    void GetInventory() {
        InventorySlots = Inventory.InventorySlots;
        int count = 0;
        foreach (int a in InventorySlots) {
            count++;
        }
        for (int i = 0; i < count; i++) {
            if (InventorySlots[i] == 1) {
                if (i == 0) {
                    OrderSlot1.sprite = Shrimp;
                }else if (i == 1) {
                    OrderSlot2.sprite = Shrimp;
                }else if (i == 2) {
                    OrderSlot3.sprite = Shrimp;
                }
            }
            if (InventorySlots[i] == 2) {
                if (i == 0) {
                    OrderSlot1.sprite = VegMeat;
                }else if (i == 1) {
                    OrderSlot2.sprite = VegMeat;
                }else if (i == 2) {
                    OrderSlot3.sprite = VegMeat;
                }
            }
            if (InventorySlots[i] == 3) {
                if (i == 0) {
                    OrderSlot1.sprite = Egg;
                }else if (i == 1) {
                    OrderSlot2.sprite = Egg;
                }else if (i == 2) {
                    OrderSlot3.sprite = Egg;
                }
            }  
            if (InventorySlots[i] == 0) {
                if (i == 0) {
                    OrderSlot1.sprite = Blank;
                }else if (i == 1) {
                    OrderSlot2.sprite = Blank;
                }else if (i == 2) {
                    OrderSlot3.sprite = Blank;
                }
            }            
        }

        for(int i = 0; i < 3; i++) {
            inventory =  string.Join("", Inventory.InventorySlots);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5) {
            SoundManager.Instance.PlayMusic("Forest");
        }
        if (SceneManager.GetActiveScene().buildIndex == 6) {
            SoundManager.Instance.PlayMusic("City");
        }
    }

    // Update is called once per frame
    void Update()
    {   
        GetInventory();
        ScoreText.text = Inventory.PlayerScore.ToString();
        LevelTimeRemaining.text = ((int)Timer.Level_Time_Remaining).ToString();
        // if ((int)Timer.Level_Time_Remaining == 30) {
        //         SoundManager.Instance.PlaySFX("Last30Sec");
        // }
    }


}
