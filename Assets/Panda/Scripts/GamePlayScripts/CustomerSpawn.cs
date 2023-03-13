using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomerSpawn : MonoBehaviour
{


    static Vector3 SeatNumber1 = new Vector3(2.558f, 0.502f, -2f); // index 1
    static Vector3 SeatNumber3 = new Vector3(3.342f, -0.241f, -2.1f); // index 2
    static Vector3 SeatNumber5 = new Vector3(4.409f, -1.497f, -2.2f); // index 3 
    static Vector3 SeatNumber7 = new Vector3(5.95f, -3.11f, -2.3f); // index 4

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
    System.Random Rnd = new System.Random();


    int GenerateRandom(int num)
    {
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
                    SoundManager.Instance.PlaySFX("Bell");
                }
                else if (TypeofCustomer == 2)
                {
                    Instantiate(Penguin, SeatNumber1, Quaternion.identity);
                    SoundManager.Instance.PlaySFX("Bell");
                }
                else if (TypeofCustomer == 3)
                {
                    Instantiate(Dog, SeatNumber1, Quaternion.identity);
                    SoundManager.Instance.PlaySFX("Bell");
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
                    SoundManager.Instance.PlaySFX("Bell");
                }
                else if (TypeofCustomer == 2)
                {
                    Instantiate(Penguin, SeatNumber3, Quaternion.identity);
                    SoundManager.Instance.PlaySFX("Bell");
                }
                else if (TypeofCustomer == 3)
                {
                    Instantiate(Dog, SeatNumber3, Quaternion.identity);
                    SoundManager.Instance.PlaySFX("Bell");
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
                    SoundManager.Instance.PlaySFX("Bell");
                }
                else if (TypeofCustomer == 2)
                {
                    Instantiate(Penguin, SeatNumber5, Quaternion.identity);
                    SoundManager.Instance.PlaySFX("Bell");
                }
                else if (TypeofCustomer == 3)
                {
                    Instantiate(Dog, SeatNumber5, Quaternion.identity);
                    SoundManager.Instance.PlaySFX("Bell");
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
                    SoundManager.Instance.PlaySFX("Bell");
                }
                else if (TypeofCustomer == 2)
                {
                    Instantiate(Penguin, SeatNumber7, Quaternion.identity);
                    SoundManager.Instance.PlaySFX("Bell");
                }
                else if (TypeofCustomer == 3)
                {
                    Instantiate(Dog, SeatNumber7, Quaternion.identity);
                    SoundManager.Instance.PlaySFX("Bell");
                }
                SeatTaken4 = true;
            }else {
                GenerateCustomer();
            }
        }
    }

    public static void Unseat(Vector3 Pos){
        if (Pos == CustomerSpawn.SeatNumber1) {
            CustomerSpawn.SeatTaken1 = false;
            Debug.Log("Seat 1 is " + SeatTaken1);
        }
        if (Pos == CustomerSpawn.SeatNumber3) {
            CustomerSpawn.SeatTaken2 = false;
        }
        if (Pos == CustomerSpawn.SeatNumber5) {
            CustomerSpawn.SeatTaken3 = false;
        }
        if (Pos == CustomerSpawn.SeatNumber7) {
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
            if (AmountOfCustomer < MaxCustomers){
                GenerateCustomer();
                TimeRemaining = 20;
            }         
        }
        

    }
}
