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
    public GameObject hand;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        isDragging = false;

    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Debug.Log("Mouse1 down");
            if (BulletScript.InAir == false && Inventory.InventoryFull == true)
            {
                isDragging = true;
                OnDragStart();
            }
        }
		if (Input.GetKeyUp(KeyCode.Mouse0)) {
            if (BulletScript.InAir == false && Inventory.InventoryFull == true)
            {
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
        Debug.Log("On drag end");
        //push the ball
        trajectory.Hide();
        if (bs != null)
        {
            bs.Stick = false;
            bs.ActivateRB();
            bs.Push(force);
        }
    }



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
