using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float TimeRemaining;
    public float TimeGiven;
    public GameObject StartPoint;
    public GameObject EndPoint;
    public GameObject Obstacle;
    public Animator Anim;
    void Start()
    {
        TimeRemaining = TimeGiven;
        // Instantiate(Obstacle, StartPoint.transform.position, Quaternion.identity);
        Anim.SetTrigger("ObstacleSpawn");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TimeRemaining > 0) {
            TimeRemaining -= Time.deltaTime;
        }else {
            // Instantiate(Obstacle, transform.position, Quaternion.identity);
            TimeRemaining = TimeGiven;
            Anim.SetTrigger("ObstacleSpawn");
        }
        
    }
}
