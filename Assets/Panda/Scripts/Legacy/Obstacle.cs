using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0.19f,-0.5f,0);
        if (transform.position.x > 3 || transform.position.y < -5) {
        Destroy(gameObject);
        }
    }
}
