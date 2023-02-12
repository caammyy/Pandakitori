using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public int[] Order = new int[3];
    public string StringOrder;
    public float TimeRemaining = 30;
    public bool OrderCorrect;
    private System.Random Rnd = new System.Random();
    int[] TypeOfOrder = {1,2};
    private void ChangeOrderToString(int[] Order) {
        StringOrder = string.Join("", Order);
        TimeRemaining = 30;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeOrderToString(GenerateRandom.CreateOrder(Order,StringOrder));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeRemaining > 0) {
            TimeRemaining -= Time.deltaTime;
        }

        if (TimeRemaining < 0) {
            ChangeOrderToString(GenerateRandom.CreateOrder(Order,StringOrder));
            TimeRemaining = 30;
            if (Inventory.PlayerScore >0) {
                Inventory.PlayerScore--;
            }   
        }


    }
    private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Bullet")) {
            if (Inventory.FoodOnHand == StringOrder) {
                Inventory.PlayerScore++;
                Debug.Log("Correct Order!, Score is " + Inventory.PlayerScore);
                ChangeOrderToString(GenerateRandom.CreateOrder(Order,StringOrder));
            }else if (Inventory.FoodOnHand != StringOrder) {
                if (Inventory.PlayerScore > 0) {
                Inventory.PlayerScore--;
                }
                Debug.Log("Wrong Order!, Score is " + Inventory.PlayerScore);
            }
        }
     }



}