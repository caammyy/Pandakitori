using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shooting_level2 : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Firepoint;
    // public float BulletForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        }
        
    }

    private void Shoot() {
        if (Inventory_level2.AmountOfFood >= 3) {
            if (BulletScript.InAir == false) {
                GameObject Bullet = Instantiate(BulletPrefab, Firepoint.position, Firepoint.rotation); 
                // Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
                 // rb.AddForce(Firepoint.right * BulletForce, ForceMode2D.Impulse);
            }
        }else {
            Debug.Log("Cant shoot! l2");
        }
        
    }
}
