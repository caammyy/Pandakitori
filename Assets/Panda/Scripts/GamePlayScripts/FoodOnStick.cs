using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodOnStick : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer Food1;
    public SpriteRenderer Food2;
    public SpriteRenderer Food3;
    public TopDownMovement Movement;
    public Animator Anim;
    public FoodOnStickEastWest EastWest;

    public Sprite Shrimp;
    public Sprite VegMeat;
    public Sprite Egg;
    public Sprite Blank;

    string inventory;
    static public int[] InventorySlots;
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

        for (int i = 0; i < 3; i++)
        {
            inventory = string.Join("", Inventory.InventorySlots);
        }
    }

    public void SetVisible()
    {
        Food1.enabled = true;
        Food2.enabled = true;
        Food3.enabled = true;
    }

    public void SetInvisible()
    {
        Food1.enabled = false;
        Food2.enabled = false;
        Food3.enabled = false;
    }

    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInventory();
        if (EastWest.visible && Shooting.Aiming == false) {
            SetInvisible();
        } 
        if (EastWest.visible == false && Shooting.Aiming == false) {
            SetVisible();
        }
        if (Movement.VerticalMovement > 0.01)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y, -2.5f);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
