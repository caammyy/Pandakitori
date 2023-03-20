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
    public Animator AnimFood;
    public GameObject Nom;
    public GameObject NomParticle;
    private System.Random Rnd = new System.Random();
    int[] TypeOfOrder = { 1, 2 };
    public GameObject Poof;


    private void ChangeOrderToSprite(int[] Order)
    {
        StringOrder = string.Join("", Order);
        if (SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 9)
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
        else if (SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 7)
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
     

        if (SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 9)
        {
            Order = new int[2];
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 7) 
        {
            Order = new int[3];
        }
        ChangeOrderToSprite(GenerateRandom.CreateOrder(Order));

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
            ChangeOrderToSprite(GenerateRandom.CreateOrder(Order));
            TimeRemaining = 30;
            Inventory.noOfCustomersMissed += 1;
            // Debug.Log("Customers Missed: " + Inventory.noOfCustomersMissed);

            if (Inventory.PlayerScore > 0)
            {
                // Inventory.PlayerScore--;
                // Anim.SetTrigger("OrderWrong");
            }
            SoundManager.Instance.PlaySFX("Min1");
            SoundManager.Instance.PlaySFX("CustomerLeave");
            StartCoroutine(WrongOrder());
        }



    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (BulletScript.CanCollide == true)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                SoundManager.Instance.PlaySFX("Eating");
                AnimFood.SetTrigger("Eating");
                if (BulletScript.FoodInAir == StringOrder && BulletScript.BlankSkewer == false)
                {
                    Instantiate(NomParticle,Nom.transform.position,Quaternion.identity);
                    Anim.SetTrigger("OrderCorrect");
                    Inventory.PlayerScore++;
                    SoundManager.Instance.PlaySFX("Plus1");
                    SoundManager.Instance.PlaySFX("CustomerHappy");
                    Inventory.noOfCustomersServed += 1;
                    ChangeOrderToSprite(GenerateRandom.CreateOrder(Order));

                }
                else if (BulletScript.FoodInAir != StringOrder || BulletScript.BlankSkewer == true)
                {
                    StartCoroutine(WrongOrder());

                }
            }
        }

    }

    IEnumerator WrongOrder()
    {
        if (Inventory.PlayerScore > 0)
        {
            // Anim.SetTrigger("OrderWrong");
            // Inventory.PlayerScore--;
            SoundManager.Instance.PlaySFX("Min1");
        }
        Inventory.noOfCustomersMissed += 1;
        SoundManager.Instance.PlaySFX("CustomerLeave");
        Instantiate(Poof,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        CustomerSpawn.Unseat(gameObject.transform.position);
    }

}