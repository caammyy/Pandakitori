using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text OrderText;
    public TMP_Text TimeRemaining;
    Customer customer;
    void Start()
    {
        customer = gameObject.GetComponent<Customer>();
    }

    // Update is called once per frame
    void Update()
    {
        OrderText.text = customer.StringOrder;
        TimeRemaining.text = ((int)customer.TimeRemaining).ToString();
    }
}
