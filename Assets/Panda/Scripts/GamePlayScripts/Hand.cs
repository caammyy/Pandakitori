using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public SpriteRenderer Food1;
    public SpriteRenderer Food2;
    public SpriteRenderer Food3;
    public Sprite Shrimp;
    public Sprite VegMeat;
    public Sprite Egg;
    public Sprite Blank;
    public float Multiplier;
    public Trajectory Traj;
    static public int[] InventorySlots;
    GameObject Arm;

    void GetInventory()
    {
        InventorySlots = Inventory.InventorySlots;
        int count = 0;
        foreach (int a in InventorySlots)
        {
            count++;
        }
        for (int i = 0; i < count; i++)
        {
            if (InventorySlots[i] == 1)
            {
                if (i == 0)
                {
                    Food1.sprite = Shrimp;
                }
                else if (i == 1)
                {
                    Food2.sprite = Shrimp;
                }
                else if (i == 2)
                {
                    Food3.sprite = Shrimp;
                }
            }
            if (InventorySlots[i] == 2)
            {
                if (i == 0)
                {
                    Food1.sprite = VegMeat;
                }
                else if (i == 1)
                {
                    Food2.sprite = VegMeat;
                }
                else if (i == 2)
                {
                    Food3.sprite = VegMeat;
                }
            }
            if (InventorySlots[i] == 3)
            {
                if (i == 0)
                {
                    Food1.sprite = Egg;
                }
                else if (i == 1)
                {
                    Food2.sprite = Egg;
                }
                else if (i == 2)
                {
                    Food3.sprite = Egg;
                }
            }
            if (InventorySlots[i] == 0)
            {
                if (i == 0)
                {
                    Food1.sprite = Blank;
                }
                else if (i == 1)
                {
                    Food2.sprite = Blank;
                }
                else if (i == 2)
                {
                    Food3.sprite = Blank;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Arm = GameObject.Find("ArmTest");

    }

    // Update is called once per frame
    void Update()
    {
            // Arm.SetActive(true);
            Vector3 difference = Traj.Dots[6].transform.position - transform.position;
            difference.Normalize();
            float rotationz = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) * Multiplier;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationz);
            GetInventory();


    }
}
