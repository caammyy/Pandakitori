using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public GameObject EndPoint;
    public float Speed;
    public float Scale;
    public float rotationSpeed;
    void Start()
    {
        EndPoint = GameObject.Find("EndPos");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate (new Vector3 (0, 0, Time.deltaTime * rotationSpeed));
        transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, Speed * Time.deltaTime);
        transform.localScale += new Vector3 (Scale,Scale,Scale);
        if (Vector2.Distance(transform.position,EndPoint.transform.position) < 0.05) {
        Destroy(gameObject);
        }
    }
}
