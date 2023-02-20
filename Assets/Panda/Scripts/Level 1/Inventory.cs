using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    static public int[] InventorySlots = new int[2];
    static public int AmountOfFood = 0;
    private int TypeOfFood;
    static public string FoodOnHand;
    public bool isColliding1;
    public bool isColliding2;
    static public int PlayerScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            DiscardItem();
        }
        if (isColliding1 && Input.GetKeyDown(KeyCode.E)) {
            if (AmountOfFood == 2) {
            Debug.Log("Inventory full, u have " + FoodOnHand);
            }
            TypeOfFood = 1;
            AddItem();
        }else if (isColliding2 && Input.GetKeyDown(KeyCode.E)) {
            if (AmountOfFood == 2) {
            Debug.Log("Inventory full, u have " + FoodOnHand);
            }
            TypeOfFood = 2;
            AddItem();
        }

    }

     private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Food1")) {
            isColliding1 = true;
        }else if (other.gameObject.CompareTag("Food2")) {
            isColliding2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Food1")) {
            isColliding1 = false;
        }else if (other.gameObject.CompareTag("Food2")) {
            isColliding2 = false;
        }
    }

    private void AddItem() {
        if (AmountOfFood < 2) {
            InventorySlots[AmountOfFood] = TypeOfFood;
        }

        FoodOnHand = string.Join("", InventorySlots);
        Debug.Log(FoodOnHand);
        AmountOfFood++;
    }

     static public void DiscardItem() {
            Array.Clear(InventorySlots, 0, InventorySlots.Length);
            AmountOfFood = 0;
            Debug.Log("Items Thrown away");
            if (Inventory.PlayerScore > 0) {
            Inventory.PlayerScore--;
            }
    }

     static public void ClearItems() {
            Array.Clear(InventorySlots, 0, InventorySlots.Length);
            AmountOfFood = 0;
            Debug.Log("Items Cleared");
    }


        
}
