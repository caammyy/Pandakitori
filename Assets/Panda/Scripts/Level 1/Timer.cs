using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    static public bool ChangeLevel = false;

    static public float Level_Time_Remaining = 120;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Level_Time_Remaining > 0) {
            Level_Time_Remaining -= Time.deltaTime;
        }else {
            ChangeLevel = true;
        }
    }
}
