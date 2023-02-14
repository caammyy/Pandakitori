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
        LinearTimer.fillAmount = customer.TimeRemaining / 30;
    }
}
