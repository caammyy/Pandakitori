using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Customer : MonoBehaviour
{
    public int[] Order;
    public string StringOrder;
    public float TimeRemaining = 30;
    public float Timer = 15;
    public bool OrderCorrect;
    public bool PlayCorrect;
    public bool PlayWrong;
    public Animator Anim;
    private System.Random Rnd = new System.Random();
    int[] TypeOfOrder = { 1, 2 };

    static public int noOfCustomersServed = 0;
    static public int noOfCustomersMissed = 0;
    private void ChangeOrderToSprite(int[] Order)
    {
        StringOrder = string.Join("", Order);
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            for (int i = 0; i < 2; i++)
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
                        // OrderSlot3.sprite = Shrimp;
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
                        // OrderSlot3.sprite = VegMeat;
                    }
                }

            }
            TimeRemaining = 30;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
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
            TimeRemaining = 30;
        }
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
        noOfCustomersMissed = 0;
        noOfCustomersServed = 0;
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Order = new int[2];
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            Order = new int[3];
        }
        ChangeOrderToSprite(GenerateRandom.CreateOrder(Order));

    }

    // Update is called once per frame
    void Update()
    {
        // Anim.ResetTrigger("OrderWrong");
        // Anim.ResetTrigger("OrderCorrect");
        if (TimeRemaining > 0)
        {
            TimeRemaining -= Time.deltaTime;
        }

        if (TimeRemaining < 0)
        {
            ChangeOrderToSprite(GenerateRandom.CreateOrder(Order));
            TimeRemaining = 30;
            noOfCustomersMissed += 1;
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
                    Anim.SetTrigger("OrderCorrect");
                    Inventory.PlayerScore++;
                    Debug.Log("Correct Order!, Score is " + Inventory.PlayerScore);
                    noOfCustomersServed += 1;
                    ChangeOrderToSprite(GenerateRandom.CreateOrder(Order));
                    // Anim.ResetTrigger("OrderCorrect");
                }
                else if (BulletScript.FoodInAir != StringOrder)
                {
                    Anim.SetTrigger("OrderWrong");
                    if (Inventory.PlayerScore > 0)
                    {
                        Inventory.PlayerScore--;
                    }
                    // Anim.ResetTrigger("OrderWrong");
                    Debug.Log("Wrong Order!, Score is " + Inventory.PlayerScore);
                    noOfCustomersMissed += 1;
                    Destroy(gameObject);
                    CustomerSpawn.Unseat(gameObject.transform.position);
                }
            }
        }
        // Anim.SetBool("OrderCorrect", false);
        // Anim.SetBool("OrderWrong", false);
    }



}