using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager_level2 : MonoBehaviour
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
    static public int[] InventorySlots = new int[2];
    void GetInventory() {
        InventorySlots = Inventory_level2.InventorySlots;
        for (int i = 0; i < 3; i++) {
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
        
    }

    // Update is called once per frame
    void Update()
    {   
        GetInventory();
        ScoreText.text = Inventory_level2.PlayerScore.ToString();
        LevelTimeRemaining.text = ((int)Timer.Level_Time_Remaining).ToString();

    }


}
