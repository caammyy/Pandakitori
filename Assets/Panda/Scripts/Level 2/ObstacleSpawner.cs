using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float TimeRemaining;
    public GameObject Obstacle;
    void Start()
    {
        Instantiate(Obstacle, transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TimeRemaining > 0) {
            TimeRemaining -= Time.deltaTime;
        }else {
            Instantiate(Obstacle, transform.position, Quaternion.identity);

            TimeRemaining = 15;
        }
        
    }
}
