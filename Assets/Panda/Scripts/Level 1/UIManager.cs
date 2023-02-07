using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public Text OrderText1;
    public Text OrderText2;
    public Text Time1;
    public Text Time2;  
    public Text ScoreText;
    public TMP_Text LevelTimeRemaining;
    public Text InventoryText;
    string inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        GetInventory();
        OrderText1.text = CustomerOrders1.StringOrder; //damn scuff, only for alpha
        OrderText2.text = CustomerOrders2.StringOrder;
        ScoreText.text = Inventory.PlayerScore.ToString();

        Time2.text = ((int)CustomerOrders1.TimeRemaining).ToString(); //swapped
        Time1.text = ((int)CustomerOrders2.TimeRemaining).ToString();
        InventoryText.text = inventory;

        LevelTimeRemaining.text = ((int)Timer.Level_Time_Remaining).ToString();

    }

    void GetInventory() {
        for(int i = 0; i < 3; i++) {
            inventory =  string.Join("", Inventory.InventorySlots);
        }
    }
}
