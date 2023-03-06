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
    public float torque;
    public int[] FoodOnBullet;

    public SpriteRenderer Food1;
    public SpriteRenderer Food2;
    public SpriteRenderer Food3;

    public Sprite Shrimp;
    public Sprite VegMeat;
    public Sprite Egg;
    public Sprite Blank;


    
    private void Start() {
        fp = GameObject.Find("FirePoint");
        // if (SceneManager.GetActiveScene().buildIndex == 5) {
        //     FoodInAir = Inventory.FoodOnHand;
        // }else if (SceneManager.GetActiveScene().buildIndex == 6){
        //     FoodInAir = Inventory_level2.FoodOnHand;
        // }
        FoodInAir = Inventory.FoodOnHand;
        FoodOnBullet = Inventory.InventorySlots;
        // Debug.Log("Food on bullet is" + FoodOnBullet[0] + FoodOnBullet[1] + FoodOnBullet[2]);
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        DeactivateRb();
        Stick = true;
        InAir = false;
        CanCollide = false;
        for (int i = 0; i < 3; i++)
        {
            if (FoodOnBullet[i] == 1)
            {
                if (i == 0)
                {
                    Food1.sprite = Shrimp;
                }
                else if (i == 1)
                {
                    Food2.sprite = Shrimp;
                }
                else if (i == 2)
                {
                    Food3.sprite = Shrimp;
                }
            }
            if (FoodOnBullet[i] == 2)
            {
                if (i == 0)
                {
                    Food1.sprite = VegMeat;
                }
                else if (i == 1)
                {
                    Food2.sprite = VegMeat;
                }
                else if (i == 2)
                {
                    Food3.sprite = VegMeat;
                }
            }
            if (FoodOnBullet[i] == 3)
            {
                if (i == 0)
                {
                    Food1.sprite = Egg;
                }
                else if (i == 1)
                {
                    Food2.sprite = Egg;
                }
                else if (i == 2)
                {
                    Food3.sprite = Egg;
                }
            }
            if (FoodOnBullet[i] == 0)
            {
                if (i == 0)
                {
                    Food1.sprite = Blank;
                }
                else if (i == 1)
                {
                    Food2.sprite = Blank;
                }
                else if (i == 2)
                {
                    Food3.sprite = Blank;
                }
            }
        }
        // Food1.transform.position = new Vector3(Food1.transform.position.x,Food1.transform.position.y,-5f);
        // Food2.transform.position = new Vector3(Food2.transform.position.x,Food2.transform.position.y,-5f);
        // Food3.transform.position = new Vector3(Food3.transform.position.x,Food3.transform.position.y,-5f);
    }

    private void Update()
    {
        pos = transform.position;
        if (Stick == true)
        {
            transform.position = new Vector3(fp.transform.position.x, fp.transform.position.y, -2f);
        }
        if (Vector2.Distance(pos, Trajectory.Target) < 1) {
            // Debug.Log("CanCollide true");
            CanCollide = true;
        } 
        if (pos.x > Trajectory.Target.x) {
            // Debug.Log("CanCollide true");
            CanCollide = false;  
            // Destroy(gameObject);  // consult john about this
            // InAir = false;
        } 
        if (transform.position.x > 10 || transform.position.y < -5) {
            Destroy(gameObject);
            InAir = false;
        }
        // transform.Rotate(Vector3)
    }

    public void Push(Vector2 force) {
        rb.AddForce(force, ForceMode2D.Impulse);
        // var impulse = (torque * Mathf.Deg2Rad) * rb.inertia;
        rb.AddTorque(torque, ForceMode2D.Force);
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
