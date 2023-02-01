using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    int TimeRemaining = 60;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeRemaining > 0) {
            // TimeRemaining =- Time.deltaTime;
        }
    }
}
