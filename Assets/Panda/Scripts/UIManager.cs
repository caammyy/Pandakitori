using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text OrderText1;
    public Text OrderText2;
    public Text Time1;
    public Text Time2;  
    public Text ScoreText;

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

        Time2.text = CustomerOrders1.TimeRemaining.ToString(); //swapped
        Time1.text = CustomerOrders2.TimeRemaining.ToString();
        InventoryText.text = inventory;
    }

    void GetInventory() {
        for(int i = 0; i < 3; i++) {
            inventory =  string.Join("", Inventory.InventorySlots);
        }
    }
}
