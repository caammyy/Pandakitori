using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerUI_level2 : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text TimeRemaining;
    public Image LinearTimer;
    Customer_level2 customer;
    void Start()
    {
        customer = gameObject.GetComponent<Customer_level2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (customer != null) {
           LinearTimer.fillAmount = customer.TimeRemaining / 30; 
        }
    }
}
