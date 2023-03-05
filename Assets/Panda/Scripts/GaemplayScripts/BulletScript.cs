using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{
    public float power = 5f;

    Rigidbody2D rb;
    LineRenderer lr;
    static public bool CanCollide;
    static public bool InAir;
    public static string FoodInAir;
    public bool Stick;
    public Vector3 pos;
    public GameObject fp; 
    
    private void Start() {
        fp = GameObject.Find("FirePoint");
        // if (SceneManager.GetActiveScene().buildIndex == 5) {
        //     FoodInAir = Inventory.FoodOnHand;
        // }else if (SceneManager.GetActiveScene().buildIndex == 6){
        //     FoodInAir = Inventory_level2.FoodOnHand;
        // }
        FoodInAir = Inventory.FoodOnHand;
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        DeactivateRb();
        Stick = true;
        InAir = false;
        CanCollide = false;
    }

    private void Update()
    {
        pos = transform.position;
        if (Stick == true)
        {
            transform.position = new Vector3(fp.transform.position.x, fp.transform.position.y, -2f);
        }
        if (Vector2.Distance(pos, Trajectory.Target) < 1) {
            Debug.Log("CanCollide true");
            CanCollide = true;
        }  
        if (transform.position.x > 10 || transform.position.y < -5) {
            Destroy(gameObject);
            InAir = false;
        }
    }

    public void Push(Vector2 force) {
        rb.AddForce(force, ForceMode2D.Impulse);
        InAir = true;
    }

    public void ActivateRB() {
        rb.isKinematic = false;
    }

    public void DeactivateRb() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }


    private void OnTriggerEnter2D(Collider2D other) {
    if (CanCollide == true) {
        if (other.gameObject.CompareTag("Customer1")) {
                Destroy(gameObject);
                InAir = false;
        }
    }
    if (other.gameObject.CompareTag("Obstacle")) {
        Destroy(gameObject);
        InAir = false;
    }
    }



}
