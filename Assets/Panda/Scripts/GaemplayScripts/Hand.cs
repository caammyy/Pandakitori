using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float Multiplier;
    public Trajectory Traj;
    GameObject Arm;
    // Start is called before the first frame update
    void Start()
    {
        Arm = GameObject.Find("ArmTest");

    }

    // Update is called once per frame
    void Update()
    {


            Arm.SetActive(true);
            Vector3 difference = Traj.Dots[1].transform.position - transform.position;
            difference.Normalize();
            float rotationz = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) * Multiplier;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationz);


    }
}
