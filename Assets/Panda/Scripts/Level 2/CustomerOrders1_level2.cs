using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CustomerOrders1_level2 : MonoBehaviour
{
    public int[] Order = new int[3];
    static public string StringOrder;
    static public float TimeRemaining = 30;
    public bool OrderCorrect;
    private System.Random Rnd = new System.Random();
    int[] TypeOfOrder = {1,2};

    // Start is called before the first frame update
    void Start()
    {
        CreateOrder();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeRemaining > 0) {
            TimeRemaining -= Time.deltaTime;
        }

        if (TimeRemaining < 0) {
            // CreateOrder();
            // TimeRemaining = 30;
            if (Inventory.PlayerScore >0) {
                Inventory.PlayerScore--;
            } 
            Destroy(gameObject);
            CustomerSpawn.Unseat(gameObject.transform.position);
        }


    }
    private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Bullet")) {
            if (Inventory.FoodOnHand == StringOrder) {
                Inventory.PlayerScore++;
                Debug.Log("Correct Order!, Score is " + Inventory.PlayerScore);
                CreateOrder();
            }else if (Inventory.FoodOnHand != StringOrder) {
                if (Inventory.PlayerScore > 0) {
                Inventory.PlayerScore--;
                }
                Debug.Log("Wrong Order!, Score is " + Inventory.PlayerScore);
            }
        }
     }

     private void CreateOrder() {
        for (int i = 0 ; i < 3; i++) {
            int RandomIndex = Rnd.Next(2) + 1;
            Order[i] = RandomIndex;
        } 
        StringOrder = string.Join("", Order);
        Debug.Log("Customer wants " + StringOrder);
        TimeRemaining = 30;
     }

}