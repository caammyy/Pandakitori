using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float power = 5f;

    Rigidbody2D rb;
    LineRenderer lr;
    Vector2 DragStartPos;
    bool Stick;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        Stick = true;
    }

    private void Update() {
            if (transform.position.x > 10 || transform.position.y < -5) {
            Destroy(gameObject);
        }

        if (Stick == true) {
            transform.position = new Vector3 (TopDownMovement.CurrentPosition.x, TopDownMovement.CurrentPosition.y, -2f);
        }
        
        if (Input.GetMouseButtonDown(0)) {
            DragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0)) {
            Vector2 DragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 _velocity = (DragEndPos - DragStartPos) * power; 

            Vector2[] trajectory = Plot(rb, (Vector2)transform.position, _velocity, 500);  
            lr.positionCount = trajectory.Length;
            Vector3[] positions = new Vector3[trajectory.Length];
            for (int i = 0; i < trajectory.Length; i++) {
                positions[i] = trajectory[i];
            }       
            lr.SetPositions(positions);
        }

        if (Input.GetMouseButtonUp(0)) {
            Stick = false;
            Vector2 DragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 _velocity = (DragEndPos - DragStartPos) * power;

            rb.velocity = _velocity;
            lr.positionCount = 0;
            Inventory.ClearItems();
        }
    }

    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps) {
        Vector2[] results = new Vector2[steps];

        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * timestep * timestep;

        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;

        for (int i = 0 ; i < steps; i++) {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }

    private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Customer1")) {
            Destroy(gameObject);
        }
     }
}
