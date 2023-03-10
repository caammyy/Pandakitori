using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomerSpawn_level2 : MonoBehaviour
{


    static Vector3 SeatNumber1 = new Vector3(2.69f, 0.29f, -1f); // index 1
    static Vector3 SeatNumber3 = new Vector3(3.16f, -0.28f, -1.1f); // index 2
    static Vector3 SeatNumber5 = new Vector3(3.99f, -1.18f, -1.2f); // index 3 
    static Vector3 SeatNumber7 = new Vector3(5.19f, -2.48f, -1.3f); // index 4

    public GameObject Bear; // index 1
    public GameObject Penguin; // index 2
    public GameObject Dog; // index 3

    public static bool SeatTaken1;
    public static bool SeatTaken2;
    public static bool SeatTaken3;
    public static bool SeatTaken4;
    static public float TimeRemaining;
    static public int AmountOfCustomer = 0;
    public int MaxCustomers;


    int GenerateRandom(int num)
    {
        System.Random Rnd = new System.Random();
        int RandomIndex = Rnd.Next(num) + 1;
        return RandomIndex;
    }

    void GenerateCustomer()
    {
        int SeatNumber = GenerateRandom(4);
        int TypeofCustomer = GenerateRandom(3);

        if (SeatNumber == 1)
        {
            if (SeatTaken1 == false)
            {
                AmountOfCustomer++;
                if (TypeofCustomer == 1)
                {
                    Instantiate(Bear, SeatNumber1, Quaternion.identity);
                }
                else if (TypeofCustomer == 2)
                {
                    Instantiate(Penguin, SeatNumber1, Quaternion.identity);
                }
                else if (TypeofCustomer == 3)
                {
                    Instantiate(Dog, SeatNumber1, Quaternion.identity);
                }
                SeatTaken1 = true;
            }else {
                GenerateCustomer();
            }
        }

        if (SeatNumber == 2)
        {
            if (SeatTaken2 == false)
            {
                AmountOfCustomer++;
                if (TypeofCustomer == 1)
                {
                    Instantiate(Bear, SeatNumber3, Quaternion.identity);
                }
                else if (TypeofCustomer == 2)
                {
                    Instantiate(Penguin, SeatNumber3, Quaternion.identity);
                }
                else if (TypeofCustomer == 3)
                {
                    Instantiate(Dog, SeatNumber3, Quaternion.identity);
                }
                SeatTaken2 = true;
            }else {
                GenerateCustomer();
            }
        }

        if (SeatNumber == 3)
        {
            if (SeatTaken3 == false)
            {
                AmountOfCustomer++;
                if (TypeofCustomer == 1)
                {
                    Instantiate(Bear, SeatNumber5, Quaternion.identity);
                }
                else if (TypeofCustomer == 2)
                {
                    Instantiate(Penguin, SeatNumber5, Quaternion.identity);
                }
                else if (TypeofCustomer == 3)
                {
                    Instantiate(Dog, SeatNumber5, Quaternion.identity);
                }
                SeatTaken3 = true;
            }else {
                GenerateCustomer();
            }
        }

        if (SeatNumber == 4)
        {
            AmountOfCustomer++;
            if (SeatTaken4 == false)
            {
                if (TypeofCustomer == 1)
                {
                    Instantiate(Bear, SeatNumber7, Quaternion.identity);
                }
                else if (TypeofCustomer == 2)
                {
                    Instantiate(Penguin, SeatNumber7, Quaternion.identity);
                }
                else if (TypeofCustomer == 3)
                {
                    Instantiate(Dog, SeatNumber7, Quaternion.identity);
                }
                SeatTaken4 = true;
            }else {
                GenerateCustomer();
            }
        }
    }

    public static void Unseat(Vector3 Pos){
        if (Pos == CustomerSpawn_level2.SeatNumber1) {
            CustomerSpawn_level2.SeatTaken1 = false;
            Debug.Log("Seat 1 is " + SeatTaken1);
        }
        if (Pos == CustomerSpawn_level2.SeatNumber3) {
            CustomerSpawn.SeatTaken2 = false;
        }
        if (Pos == CustomerSpawn_level2.SeatNumber5) {
            CustomerSpawn.SeatTaken3 = false;
        }
        if (Pos == CustomerSpawn_level2.SeatNumber7) {
            CustomerSpawn.SeatTaken4 = false;
        }
        AmountOfCustomer--;
    }



    // Start is called before the first frame update
    void Start()
    {
        AmountOfCustomer = 0;
        TimeRemaining = 20;
        SeatTaken1 = false;
        SeatTaken2 = false;
        SeatTaken3 = false;
        SeatTaken4 = false;
        GenerateCustomer();
    }

    // Update is called once per frame
    void Update()
    {

        if (TimeRemaining > 0)
        {
            TimeRemaining -= Time.deltaTime;
        }

        if (TimeRemaining <= 0)
        {
            if (AmountOfCustomer <= MaxCustomers) {
                GenerateCustomer();
                TimeRemaining = 20;
            } 
        }
        

    }
}
