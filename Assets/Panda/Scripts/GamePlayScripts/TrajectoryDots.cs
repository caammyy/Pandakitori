using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryDots : MonoBehaviour
{
    public SpriteRenderer ball;
    static public bool IsTouching;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Ball Spawned");
        ball = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsTouching) {
            ball.color = new Color (0f,1f,0f,1f);
        }else {
            ball.color = new Color (1f,1f,1f,1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Customer1"))
        {
           IsTouching = true;
        //    Debug.Log("Touching");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Customer1"))
        {
          IsTouching = false;
        //   Debug.Log("not touching");
        }

    }
}
