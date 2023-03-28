using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float TimeRemaining;
    public float TimeGiven;
    public GameObject StartPoint;
    public GameObject EndPoint;
    public GameObject Obstacle;
    public Animator Anim;
    public GameObject Poof;
    void Start()
    {
        TimeRemaining = TimeGiven;
        // Instantiate(Obstacle, StartPoint.transform.position, Quaternion.identity);
        StartCoroutine(CountDownObstacle());
        // Instantiate(Poof, StartPoint.transform.position, transform.rotation);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TimeRemaining > 0) {
            TimeRemaining -= Time.deltaTime;
        }else {
            // Instantiate(Obstacle, transform.position, Quaternion.identity);
            TimeRemaining = TimeGiven;
            Anim.SetTrigger("ObstacleSpawn");
            Instantiate(Poof, StartPoint.transform.position, transform.rotation);
            SoundManager.Instance.PlaySFX("Train");
        }
        
    }

    IEnumerator CountDownObstacle() {
        yield return new WaitForSeconds(3f);
        Anim.SetTrigger("ObstacleSpawn");
        SoundManager.Instance.PlaySFX("Train");
    }
}
