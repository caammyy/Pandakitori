using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text OrderText;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrderText.text = CustomerOrders.StringOrder;
        ScoreText.text = Inventory.PlayerScore.ToString();
    }
}
