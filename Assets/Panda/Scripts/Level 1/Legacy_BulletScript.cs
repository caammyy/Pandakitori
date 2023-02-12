using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legacy_BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 10 || transform.position.y < -5) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Customer1")) {
            Destroy(gameObject);
        }
     }
}
