using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float power = 5f;

    Rigidbody2D rb;
    LineRenderer lr;
    Vector2 DragStartPos;
    Vector3 Target;
    Vector3 StartPoint;
    bool Stick;
    static public bool CanCollide;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        Stick = true;
        CanCollide = false;
    }

    private void Update() {

        StartPoint = transform.position;
        if (Vector2.Distance(transform.position, Target) < 1.1) {
            Debug.Log("CanCollide true");
            CanCollide = true;
        }        

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
            Target = lr.GetPosition(lr.positionCount - 1);
            Debug.Log("target " + Target.x);
            lr.positionCount = 0;
            Inventory.ClearItems();
            Inventory_level2.ClearItems();
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
    if (CanCollide == true) {
        if (other.gameObject.CompareTag("Customer1")) {
                Destroy(gameObject);
        }
    }
    if (other.gameObject.CompareTag("Obstacle")) {
        Destroy(gameObject);
    }
    }

}
