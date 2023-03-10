using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text TimeRemaining;
    public Image LinearTimer;
    Customer customer;
    void Start()
    {
        customer = gameObject.GetComponent<Customer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (customer.TimeRemaining <30) {
            LinearTimer.color = new Color32(25,188,5,255);
        }
        if (customer.TimeRemaining < 20) {
            LinearTimer.color = new Color32(255,255,17,255);
        }
        if (customer.TimeRemaining < 10) {
            LinearTimer.color = new Color32(255,0,0,255);
        }
        LinearTimer.fillAmount = customer.TimeRemaining / 30;
    }
}
