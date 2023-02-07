using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    static public float Level_Time_Remaining = 60;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Level_Time_Remaining > 0) {
            Level_Time_Remaining -= Time.deltaTime;
        }else if(Level_Time_Remaining == 0) {
            Debug.Log("Time Run Out!");
            Level_Time_Remaining = 0;
        }
    }
}
