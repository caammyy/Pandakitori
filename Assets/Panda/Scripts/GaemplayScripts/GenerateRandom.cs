using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GenerateRandom : MonoBehaviour
{
    // Start is called before the first frame update
    public static int[] CreateOrder(int[] Order)
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            System.Random Rnd = new System.Random();
            for (int i = 0; i < 2; i++)
            {
                int RandomIndex = Rnd.Next(2) + 1;
                Order[i] = RandomIndex;
            }
            return Order;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 7)
        {
            System.Random Rnd = new System.Random();
            for (int i = 0; i < 3; i++)
            {
                int RandomIndex = Rnd.Next(3) + 1;
                Order[i] = RandomIndex;
            }
            return Order;
        }
        return null;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
