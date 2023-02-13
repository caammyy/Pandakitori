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
    private void ChangeOrderToSprite(int[] Order) {
        StringOrder = string.Join("", Order);
        for (int i = 0; i < 3; i++) {
            if (Order[i] == 1) {
                if (i == 0) {
                    OrderSlot1.sprite = Shrimp;
                }else if (i == 1) {
                    OrderSlot2.sprite = Shrimp;
                }else if (i == 2) {
                    OrderSlot3.sprite = Shrimp;
                }
            }
            if (Order[i] == 2) {
                if (i == 0) {
                    OrderSlot1.sprite = VegMeat;
                }else if (i == 1) {
                    OrderSlot2.sprite = VegMeat;
                }else if (i == 2) {
                    OrderSlot3.sprite = VegMeat;
                }
            }

        }
        TimeRemaining = 30;
    }
    public SpriteRenderer OrderSlot1;
    public SpriteRenderer OrderSlot2;
    public SpriteRenderer OrderSlot3;
    public Sprite Shrimp;
    public Sprite VegMeat;

    // Start is called before the first frame update
    void Start()
    {
        ChangeOrderToSprite(GenerateRandom.CreateOrder(Order));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeRemaining > 0) {
            TimeRemaining -= Time.deltaTime;
        }

        if (TimeRemaining < 0) {
            ChangeOrderToSprite(GenerateRandom.CreateOrder(Order));
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
                ChangeOrderToSprite(GenerateRandom.CreateOrder(Order));
            }else if (Inventory.FoodOnHand != StringOrder) {
                if (Inventory.PlayerScore > 0) {
                Inventory.PlayerScore--;
                }
                Debug.Log("Wrong Order!, Score is " + Inventory.PlayerScore);
            }
        }
     }



}