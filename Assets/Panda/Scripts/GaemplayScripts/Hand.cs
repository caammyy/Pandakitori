using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float Multiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.rotation = Quaternion.Euler(0.0f, 0.0f, Trajectory.Angle); 
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationz = (Mathf.Atan2(difference.y * -1,difference.x * -1) * Mathf.Rad2Deg) * Multiplier;

        transform.rotation = Quaternion.Euler(0f,0f,rotationz);
        
    }
}
