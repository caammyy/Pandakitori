using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    static public int[] InventorySlots;
    static public int AmountOfFood = 0;
    private int TypeOfFood;
    static public string FoodOnHand;
    public bool isColliding1;
    public bool isColliding2;
    public bool isColliding3;
    static public int PlayerScore = 0;
    static public bool InventoryFull;


    // Start is called before the first frame update
    void Start()
    {
        AmountOfFood = 0;
        PlayerScore = 0;
        InventoryFull = false;
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            InventorySlots = new int[2];
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            InventorySlots = new int[3];
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DiscardItem();
        }
        if (isColliding1 && Input.GetKeyDown(KeyCode.E))
        {
            // if (AmountOfFood == 2)
            // {
            //     Debug.Log("Inventory full, u have " + FoodOnHand);
            // }
            TypeOfFood = 1;
            AddItem();
        }
        else if (isColliding2 && Input.GetKeyDown(KeyCode.E))
        {
            // if (AmountOfFood == 2)
            // {
            //     Debug.Log("Inventory full, u have " + FoodOnHand);
            // }
            TypeOfFood = 2;
            AddItem();
        }else if (isColliding3 && Input.GetKeyDown(KeyCode.E))
        {
            // if (AmountOfFood == 2)
            // {
            //     Debug.Log("Inventory full, u have " + FoodOnHand);
            // }
            TypeOfFood = 3;
            AddItem();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food1"))
        {
            isColliding1 = true;
        }
        else if (other.gameObject.CompareTag("Food2"))
        {
            isColliding2 = true;
        }else if (other.gameObject.CompareTag("Food3"))
        {
            isColliding3 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food1"))
        {
            isColliding1 = false;
        }
        else if (other.gameObject.CompareTag("Food2"))
        {
            isColliding2 = false;
        }else if (other.gameObject.CompareTag("Food3"))
        {
            isColliding3 = false;
        }
    }

    private void AddItem()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (AmountOfFood < 2)
            {
                InventorySlots[AmountOfFood] = TypeOfFood;
                FoodOnHand = string.Join("", InventorySlots);
                Debug.Log(FoodOnHand);
                AmountOfFood++;

                if (AmountOfFood == 2) {
                    InventoryFull = true;
                }
            }


        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            if (AmountOfFood < 3)
            {
                InventorySlots[AmountOfFood] = TypeOfFood;
                FoodOnHand = string.Join("", InventorySlots);
                Debug.Log(FoodOnHand);
                AmountOfFood++;

                if (AmountOfFood == 3)
                {
                    InventoryFull = true;
                }
            }


        }
    }

    static public void DiscardItem()
    {
        Array.Clear(InventorySlots, 0, InventorySlots.Length);
        AmountOfFood = 0;
        Debug.Log("Items Thrown away");
        InventoryFull = false;
    }

    static public void ClearItems()
    {
        Array.Clear(InventorySlots, 0, InventorySlots.Length);
        AmountOfFood = 0;
        Debug.Log("Items Cleared");
        InventoryFull = false;
    }



}
