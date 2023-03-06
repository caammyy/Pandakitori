using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    // Start is called before the first frame update
    public int dotsNumber;
    public GameObject dotsParent;
    public GameObject dotPrefab;
    public float dotSpacing;
	[SerializeField] [Range (0.01f, 0.3f)] float dotMinScale;
	[SerializeField] [Range (0.3f, 1f)] float dotMaxScale;
    Transform[] dotsList;
	public GameObject[] Dots;
    Vector2 pos;
    float timeStamp;
    public static Vector3 Target;
	static public float Angle;
	public bool TrajActive;
    void Start()
    {
        //hide trajectory in the start
		Hide();
		//prepare dots
		PrepareDots ();
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }

    void PrepareDots() {
        dotsList = new Transform[dotsNumber];
        dotPrefab.transform.localScale = Vector3.one * dotMaxScale;
		float scale = dotMaxScale;
		float scaleFactor = scale / dotsNumber;

		for (int i = 0; i < dotsNumber; i++) {
			dotsList [i] = Instantiate (dotPrefab, null).transform;
			dotsList [i].parent = dotsParent.transform;

			dotsList [i].localScale = Vector3.one * scale;
			if (scale > dotMinScale)
				scale -= scaleFactor;
		}


		Dots = new GameObject[dotsNumber];
		for (int i = 0; i < dotsNumber; i++) {
			Dots[i] = dotsList[i].gameObject;
		}

		for (int i = 0; i < dotsNumber-1; i++) {
			Collider2D Col;
			Col = Dots[i].GetComponent<Collider2D>();
			Col.enabled = false; 
		}	

    }

	public void UpdateDots (Vector3 ballPos, Vector2 forceApplied)
	{
		timeStamp = dotSpacing;
		for (int i = 0; i < dotsNumber; i++) {
			pos.x = (ballPos.x + forceApplied.x * timeStamp);
			pos.y = (ballPos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2f;	
			dotsList [i].position = pos;
			timeStamp += dotSpacing;
		}
        Target = dotsList[dotsNumber-1].position;

		// Angle = Vector2.SignedAngle(TopDownMovement.CurrentPosition, Dots[4].transform.position) * -1;
		// Debug.Log(Angle);
	}

	public void Show ()
	{
		dotsParent.SetActive (true);
		TrajActive = true;
	}

	public void Hide ()
	{
		dotsParent.SetActive (false);
		TrajActive = false;
	}

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Customer1")) {
    //         Debug.Log("sdkoasjdko");
    //         SpriteRenderer sr = dotPrefab.GetComponent<SpriteRenderer>();
    //         sr.color = new Color(0, 1, 0, 1);
    //     }
    // }
}
