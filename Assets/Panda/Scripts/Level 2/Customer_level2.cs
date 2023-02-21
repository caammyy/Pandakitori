using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Customer_level2 : MonoBehaviour
{
    public int[] Order = new int[3];
    public string StringOrder;
    public float TimeRemaining = 25;
    public float Timer = 15;
    public bool OrderCorrect;
    private System.Random Rnd = new System.Random();
    int[] TypeOfOrder = { 1, 2 };
    private void ChangeOrderToSprite(int[] Order)
    {
        StringOrder = string.Join("", Order);
        Debug.Log(StringOrder);
        for (int i = 0; i < 3; i++)
        {
            if (Order[i] == 1)
            {
                if (i == 0)
                {
                    OrderSlot1.sprite = Shrimp;
                }
                else if (i == 1)
                {
                    OrderSlot2.sprite = Shrimp;
                }
                else if (i == 2)
                {
                    OrderSlot3.sprite = Shrimp;
                }
            }
            if (Order[i] == 2)
            {
                if (i == 0)
                {
                    OrderSlot1.sprite = VegMeat;
                }
                else if (i == 1)
                {
                    OrderSlot2.sprite = VegMeat;
                }
                else if (i == 2)
                {
                    OrderSlot3.sprite = VegMeat;
                }
                else if (i == 3)
                {
                    OrderSlot3.sprite = VegMeat;
                }
            }
            if (Order[i] == 3)
            {
                if (i == 0)
                {
                    OrderSlot1.sprite = Egg;
                }
                else if (i == 1)
                {
                    OrderSlot2.sprite = Egg;
                }
                else if (i == 2)
                {
                    OrderSlot3.sprite = Egg;
                }
                else if (i == 3)
                {
                    OrderSlot3.sprite = Egg;
                }
            }            

        }
        TimeRemaining = 25;
    }
    public SpriteRenderer OrderSlot1;
    public SpriteRenderer OrderSlot2;
    public SpriteRenderer OrderSlot3;
    public Sprite Shrimp;
    public Sprite VegMeat;
    public Sprite Egg;

    // Start is called before the first frame update
    void Start()
    {
        ChangeOrderToSprite(GenerateRandom_level2.CreateOrder(Order));

    }

    // Update is called once per frame
    void Update()
    {
        if (TimeRemaining > 0)
        {
            TimeRemaining -= Time.deltaTime;
        }

        if (TimeRemaining < 0)
        {
            ChangeOrderToSprite(GenerateRandom_level2.CreateOrder(Order));
            TimeRemaining = 25;
            if (Inventory.PlayerScore > 0)
            {
                Inventory.PlayerScore--;
            }
        }

        // if (Timer > 0)
        // {
        //     Timer -= Time.deltaTime;
        // }

        // if (Timer < 0)
        // {
        //     Destroy(gameObject);
        //     CustomerSpawn.Unseat(gameObject.transform.position);
        // } 


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (BulletScript.CanCollide == true)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                if (BulletScript.FoodInAir == StringOrder)
                {
                    Inventory_level2.PlayerScore++;
                    Debug.Log("Correct Order!, Score is " + Inventory_level2.PlayerScore);
                    ChangeOrderToSprite(GenerateRandom.CreateOrder(Order));
                }
                else if (BulletScript.FoodInAir != StringOrder)
                {
                    if (Inventory_level2.PlayerScore > 0)
                    {
                        Inventory_level2.PlayerScore--;
                    }
                    Debug.Log("Wrong Order!, Score is " + Inventory_level2.PlayerScore);
                    Destroy(gameObject);
                    CustomerSpawn_level2.Unseat(gameObject.transform.position);
                }
            }
        }
    }



}