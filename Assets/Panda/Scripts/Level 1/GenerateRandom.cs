using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateRandom : MonoBehaviour
{
    // Start is called before the first frame update
    public static int[] CreateOrder(int[] Order) {
        System.Random Rnd = new System.Random();
        for (int i = 0 ; i < 3; i++) {
            int RandomIndex = Rnd.Next(2) + 1;
            Order[i] = RandomIndex;
        } 
        return Order;
     }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
