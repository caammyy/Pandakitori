using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float Scale;
    private float HorizontalMovement;
    public float VerticalMovement;
    // private bool IsMoving;
    public Rigidbody2D Rigid;
    public Animator Anim;
    private bool WallCheck;
    private float YReAdj;
    private Vector2 LookDir;
    private Vector2 MousePosition;
    public Camera Cam;
    static public float Angle;
    public float Size;
    static public Vector2 CurrentPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        // IsMoving = false;
        WallCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        HorizontalMovement = Input.GetAxis("Horizontal");
        VerticalMovement = Input.GetAxis("Vertical");
        YReAdj = (transform.position.y * -1) + 4;

        if (HorizontalMovement != 0 || VerticalMovement != 0) {
            Anim.SetBool("Moving", true);
        }else{
            Anim.SetBool("Moving", false);
        }

        transform.localScale = new Vector3 (Size + (YReAdj * Scale) ,Size + (YReAdj * Scale), Size + (YReAdj * Scale));
        // transform.localScale = new Vector3 (YReAdj/100 , YReAdj/100 , YReAdj/100);

        Rigid.velocity = new Vector2 (HorizontalMovement * MoveSpeed, VerticalMovement * MoveSpeed);

        Anim.SetFloat("VerticleSpeed", Rigid.velocity.y);
        Anim.SetFloat("HorizontalSpeed", HorizontalMovement);
        // Anim.SetFloat("HorizontalSpeed", Rigid.velocity.x);
        // Anim.SetBool("IsMoving", IsMoving);

        MousePosition = Cam.ScreenToWorldPoint(Input.mousePosition);
        LookDir = MousePosition - Rigid.position;
        Angle = Mathf.Atan2(LookDir.x, LookDir.y) * Mathf.Rad2Deg -90f;

        // IsMoving = false;
        CurrentPosition = transform.position;
    }

     private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Grounded")) {
            WallCheck = true;
            Debug.Log("Touching wall" + WallCheck);
        }
    }

        private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Grounded")) {
            WallCheck = false;
            Debug.Log("Stop touching wall" + WallCheck);

        }
    }

}
