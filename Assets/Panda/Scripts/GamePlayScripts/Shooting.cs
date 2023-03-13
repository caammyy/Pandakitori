using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameObject Bullet;
    BulletScript bs;
    public Transform Firepoint;
    public float pushForce;
    // public float DisM;
    public Vector3 DirM;
    Camera cam;
    public Trajectory trajectory;
    Vector2 startPoint;
	Vector2 endPoint;
	Vector2 direction;
	Vector2 force;
	float distance;
    bool isDragging;
    public Animator Anim;
    public FoodOnStick FoodOnStick;
    public FoodOnStickEastWest FoodOnStickEastWest;
    static public bool Aiming;
    public GameObject Arm;
    SpriteRenderer armSR;
    public SpriteRenderer Player;
    public SpriteRenderer Food1;
    public SpriteRenderer Food2;
    public SpriteRenderer Food3;
    // public SpriteRenderer Food1Flipped;
    // public SpriteRenderer Food2Flipped;
    // public SpriteRenderer Food3Flipped;

    // Start is called before the first frame update
    void Start()
    {
        Aiming = false;
        cam = Camera.main;
        isDragging = false;
        armSR = Arm.GetComponent<SpriteRenderer>();
        armSR.enabled = false;
        Food1.enabled = false;
        Food2.enabled = false;
        Food3.enabled = false;
        BulletScript.InAir = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Debug.Log("Mouse1 down");
            if (BulletScript.InAir == false )
            {
                SoundManager.Instance.PlaySFX("Aim(Stretch)");
                armSR.enabled = true;
                Food1.enabled = true;
                Food2.enabled = true;
                Food3.enabled = true;
                Aiming = true;
                FoodOnStick.SetInvisible();
                FoodOnStickEastWest.SetInvisible();
                Anim.SetBool("Aiming", true);
                isDragging = true;
                OnDragStart();
            }
        }
		if (Input.GetKeyUp(KeyCode.Mouse0)) {
            Debug.Log("Mouse1 up");
            if (BulletScript.InAir == false )
            {
                SoundManager.Instance.PlaySFX("Release");
                armSR.enabled = false;
                Food1.enabled = false;
                Food2.enabled = false;
                Food3.enabled = false;
                Aiming = false;
                FoodOnStick.SetVisible();
                FoodOnStickEastWest.SetVisible();
                Anim.SetBool("Aiming", false);
                isDragging = false;
                OnDragEnd();
                Inventory.ClearItems();
            }
		}

		if (isDragging) {
			OnDrag ();
		}

    }


    void OnDragStart() {
        Debug.Log("On drag start");
        Vector3 pos = new Vector3 (Firepoint.transform.position.x, Firepoint.transform.position.y, -2.5f);
        Bullet = Instantiate(BulletPrefab, pos, Firepoint.transform.rotation);
        bs = Bullet.GetComponent<BulletScript>();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        trajectory.Show();
    }

    void OnDrag() {
        if (BulletScript.AimingRight == false) {
            Flip();
        }
        if (BulletScript.AimingRight) {
            UnFlip();
        }

        // Debug.Log("On drag");
        endPoint = DirM + cam.ScreenToWorldPoint (Input.mousePosition);
		distance = Vector2.Distance (startPoint, endPoint);
		direction = (startPoint - endPoint).normalized;
		force = direction * distance * pushForce;
		//just for debug
		// Debug.DrawLine (startPoint, endPoint);
		trajectory.UpdateDots (bs.pos, force);
    }

    public void OnDragEnd()
    {
        UnFlip();
        Debug.Log("On drag end");
        //push the ball
        trajectory.Hide();
        if (bs != null)
        {
            Debug.Log("bs not null, OnDragEnd Push");
            bs.Stick = false;
            bs.ActivateRB();
            bs.Push(force);
        }
    }

    public void Flip(){
        Player.flipX = true;
        armSR.flipY = true;
        Food1.flipY = true;
        Food2.flipY = true;
        Food3.flipY = true;
    }
    public void UnFlip(){
        Player.flipX = false;
        armSR.flipY = false;
        Food1.flipY = false;
        Food2.flipY = false;
        Food3.flipY = false;
    }

    // public void EnableFood()
    // {
    //     armSR.enabled = true;
    //     Food1.enabled = true;
    //     Food2.enabled = true;
    //     Food3.enabled = true;
    // }

    // public void DisableFood()
    // {
    //     armSR.enabled = false;
    //     Food1.enabled = false;
    //     Food2.enabled = false;
    //     Food3.enabled = false;
    // }

    // public void EnableFoodFlipped() {
    //     armSR.enabled = true;
    //     Food1Flipped.enabled = true;
    //     Food2Flipped.enabled = true;
    //     Food3Flipped.enabled = true;
    // }
    // public void DisableFoodFlipped() {
    //     armSR.enabled = false;
    //     Food1Flipped.enabled = false;
    //     Food2Flipped.enabled = false;
    //     Food3Flipped.enabled = true;
    // }



    // private void Shoot()
    // {
    //     if (SceneManager.GetActiveScene().buildIndex == 5)
    //     {
    //         if (Inventory.AmountOfFood >= 2)
    //         {
    //             if (BulletScript.InAir == false)
    //             {
    //                 GameObject Bullet = Instantiate(BulletPrefab, Firepoint.position, Firepoint.rotation);
    //                 // Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
    //                 // rb.AddForce(Firepoint.right * BulletForce, ForceMode2D.Impulse);               
    //             }
    //         }
    //         else
    //         {
    //             Debug.Log("Cant shoot!");
    //         }
    //     }
    //     else if (SceneManager.GetActiveScene().buildIndex == 6)
    //     {
    //         if (Inventory.AmountOfFood >= 3)
    //         {
    //             if (BulletScript.InAir == false)
    //             {
    //                 GameObject Bullet = Instantiate(BulletPrefab, Firepoint.position, Firepoint.rotation);
    //                 // Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
    //                 // rb.AddForce(Firepoint.right * BulletForce, ForceMode2D.Impulse);               
    //             }
    //         }
    //         else
    //         {
    //             Debug.Log("Cant shoot!");
    //         }
    //     }
    // }
}
