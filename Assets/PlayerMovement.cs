using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D Rigid;
    public Animator Animator;
    public SpriteRenderer Spr;
    public float Speed;
    private float Velocity;
    private float VerticleVelocity;
    public float Jump;
    public bool IsJumping;
    public bool FacingRight;

    // Start is called before the first frame update
    void Start()
    {
        FacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Velocity = Input.GetAxis("Horizontal");
        VerticleVelocity = Input.GetAxis("Vertical");
        

        if (Velocity < 0 && FacingRight == true) {
            Spr.flipX = true;
            FacingRight = false;
        }
       
        if (Velocity > 0 && FacingRight == false) {
            Spr.flipX = false;
            FacingRight = true;
        }



        Rigid.velocity = new Vector2(Velocity * Speed, Rigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsJumping == false) {  
            Rigid.AddForce(new Vector2(Rigid.velocity.x, Jump));
        }

        Animator.SetFloat("Speed", Mathf.Abs(Rigid.velocity.x));
        Animator.SetBool("IsJump", IsJumping);

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Grounded")) {
            IsJumping = false;
        }
    }

        private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Grounded")) {
            IsJumping = true;
        }
    }

}
