using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory_level2 : MonoBehaviour
{
    static public int[] InventorySlots = new int[3];
    static public int AmountOfFood = 0;
    private int TypeOfFood;
    static public string FoodOnHand;
    public bool isColliding1;
    public bool isColliding2;
    public bool isColliding3;
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
            if (AmountOfFood == 3) {
            Debug.Log("Inventory full, u have " + FoodOnHand);
            }else{
            TypeOfFood = 1;
            AddItem();               
            }
        }else if (isColliding2 && Input.GetKeyDown(KeyCode.E)) {
            if (AmountOfFood == 3) {
            Debug.Log("Inventory full, u have " + FoodOnHand);
            }else{
            TypeOfFood = 2;
            AddItem();              
            }
        }else if (isColliding3 && Input.GetKeyDown(KeyCode.E)) {
            if (AmountOfFood == 3) {
            Debug.Log("Inventory full, u have " + FoodOnHand);
            }else{
            TypeOfFood = 3;
            AddItem();
            }
        }

    }

     private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Food1")) {
            isColliding1 = true;
        }else if (other.gameObject.CompareTag("Food2")) {
            isColliding2 = true;
        }else if (other.gameObject.CompareTag("Food3")) {
            isColliding3 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Food1")) {
            isColliding1 = false;
        }else if (other.gameObject.CompareTag("Food2")) {
            isColliding2 = false;
        }else if (other.gameObject.CompareTag("Food3")) {
            isColliding3 = false;
        }
    }

    private void AddItem() {
        if (AmountOfFood < 3) {
            InventorySlots[AmountOfFood] = TypeOfFood;
        }

        FoodOnHand = string.Join("", InventorySlots);
        Debug.Log(FoodOnHand);
        AmountOfFood++;
    }

     static public void DiscardItem() {
            Array.Clear(InventorySlots, 0, InventorySlots.Length);
            AmountOfFood = 0;
            Debug.Log("Items thrown away");
            if (Inventory_level2.PlayerScore > 0) {
                Inventory_level2.PlayerScore--;
            }
    }

     static public void ClearItems() {
            Array.Clear(InventorySlots, 0, InventorySlots.Length);
            AmountOfFood = 0;
            Debug.Log("Items Cleared");
    }


        
}
