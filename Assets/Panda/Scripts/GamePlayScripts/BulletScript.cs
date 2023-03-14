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
    static public bool AimingRight;
    public bool Stick;
    public Vector3 pos;
    public GameObject fp; 
    public float torque;
    public int[] FoodOnBullet;

    public SpriteRenderer Food1;
    public SpriteRenderer Food2;
    public SpriteRenderer Food3;
    public SpriteRenderer Skewer;

    public Sprite Shrimp;
    public Sprite VegMeat;
    public Sprite Egg;
    public Sprite Blank;
    public GameObject DestroyParticle;
    public static bool BlankSkewer;

    public void GetFoodOnStick() {
        FoodOnBullet = Inventory.InventorySlots;
        int i = 0;
        if (SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 9) {
            i = 2;
        }
        if (SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 7) {
            i = 3;
        }
        for (int k = 0; k < i; k++)
        {
            if (FoodOnBullet[k] == 1)
            {
                if (k == 0)
                {
                    Food1.sprite = Shrimp;
                }
                else if (k == 1)
                {
                    Food2.sprite = Shrimp;
                }
                else if (k == 2)
                {
                    Food3.sprite = Shrimp;
                }
            }
            if (FoodOnBullet[k] == 2)
            {
                if (k == 0)
                {
                    Food1.sprite = VegMeat;
                }
                else if (k == 1)
                {
                    Food2.sprite = VegMeat;
                }
                else if (k == 2)
                {
                    Food3.sprite = VegMeat;
                }
            }
            if (FoodOnBullet[k] == 3)
            {
                if (k == 0)
                {
                    Food1.sprite = Egg;
                }
                else if (k == 1)
                {
                    Food2.sprite = Egg;
                }
                else if (k == 2)
                {
                    Food3.sprite = Egg;
                }
            }
            if (FoodOnBullet[k] == 0)
            {
                if (k == 0)
                {
                    Food1.sprite = Blank;
                }
                else if (k == 1)
                {
                    Food2.sprite = Blank;
                }
                else if (k == 2)
                {
                    Food3.sprite = Blank;
                }
            }
        }
    }
    

    
    private void Start() {
        BlankSkewer = false;
        fp = GameObject.Find("FirePoint");
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        DeactivateRb();
        Stick = true;
        InAir = false;
        CanCollide = false;
        }
        // Food1.transform.position = new Vector3(Food1.transform.position.x,Food1.transform.position.y,-5f);
        // Food2.transform.position = new Vector3(Food2.transform.position.x,Food2.transform.position.y,-5f);
        // Food3.transform.position = new Vector3(Food3.transform.position.x,Food3.transform.position.y,-5f);
    

    private void Update()
    {
        if (Food1.sprite == Blank && Food2.sprite == Blank && Food3.sprite == Blank) {
            BlankSkewer = true;
        }else{
            BlankSkewer = false;
        }
        if (Inventory.DiscAim) {
            // Debug.Log("DiscAim Destroy");
            Destroy(gameObject);
            Inventory.DiscAim = false; 
        }
        if (InAir == false) {
            SetInvisible();
            FoodInAir = Inventory.FoodOnHand;
            GetFoodOnStick();
        }else if (InAir == true) {
            SetVisible();
        }
        pos = transform.position;
        if (Stick == true)
        {
            transform.position = new Vector3(fp.transform.position.x, fp.transform.position.y, -2.5f);
        }

        if (Vector2.Distance(pos, Trajectory.Target) < 1)
        {
            if (InAir)
            {
                StartCoroutine(DestroyAtTarget());
            }
        }

        // if (InAir == true)
        // {
        //     if (AimingRight)
        //     {
        //         if (pos.x > Trajectory.Target.x)
        //         {
        //             // Debug.Log("CanCollide true");
        //             Destroy(gameObject);
        //             // CanCollide = false;
        //             // Destroy(gameObject);  // consult john about this
        //             InAir = false;
        //         }
        //     }

        // }

        if (transform.position.x > 10 || transform.position.y < -5) {
            Destroy(gameObject);
            InAir = false;
        }

        if (InAir == false && pos.x < Trajectory.Target.x) {
            AimingRight = true;
            // Debug.Log("Aiming right");
        }else if (InAir == false && pos.x > Trajectory.Target.x) {
            AimingRight = false;
            // Debug.Log("Aiming left");
        }
    }

    public void Push(Vector2 force) {
        // Debug.Log("BulletScript Push");
        rb.AddForce(force, ForceMode2D.Impulse);
        // var impulse = (torque * Mathf.Deg2Rad) * rb.inertia;
        rb.AddTorque(torque, ForceMode2D.Force);
        InAir = true;
    }

    public void ActivateRB()
    {
        // Debug.Log("RB Activated");
        if (rb != null)
        {
            rb.isKinematic = false;
        }else {
            // Debug.Log("rb is null");
        }
    }

    public void DeactivateRb()
    {
        // Debug.Log("RB Deactivated");
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;
        }else {
            // Debug.Log("rb is null");
        }

    }


    private void OnTriggerEnter2D(Collider2D other) {
    if (CanCollide == true) {
        if (other.gameObject.CompareTag("Customer1")) {
                Destroy(gameObject);
                InAir = false;
        }
    }
    if (other.gameObject.CompareTag("Obstacle")) {
        Debug.Log("Obstacle hit");
        Instantiate(DestroyParticle, pos, transform.rotation);
        SoundManager.Instance.PlaySFX("FoodSplat");  
        Destroy(gameObject);
        InAir = false;
    }
    }
    // public void ClearFoodInAir() {
    //     FoodInAir = "000";
    // }
    public void SetVisible() {
        // Debug.Log("FoodVisible");
        Food1.enabled = true;
        Food2.enabled = true;
        Food3.enabled = true;
        Skewer.enabled = true;
    }
    public void SetInvisible() {
        // Debug.Log("FoodInvisible");
        Food1.enabled = false;
        Food2.enabled = false;
        Food3.enabled = false;
        Skewer.enabled = false;
    }

    IEnumerator DestroyAtTarget()
    {
        CanCollide = true;
        yield return new WaitForSeconds(0.2f);
        Instantiate(DestroyParticle, pos, transform.rotation);
        Destroy(gameObject);
        InAir = false;
        SoundManager.Instance.PlaySFX("FoodSplat");        
    }

}
