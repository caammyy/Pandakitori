using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    static public bool ChangeLevel = false;

    static public float Level_Time_Remaining;

    [SerializeField] public GameObject endTransition;

    // Start is called before the first frame update
    void Start()
    {
        Level_Time_Remaining = 120;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Level_Time_Remaining > 0) {
            Level_Time_Remaining -= Time.deltaTime;
        }else {
            ChangeLevel = true;
            endTransition.SetActive(true);
            Invoke("OpenScene", 1.5f);
        }
    }

    public void OpenScene()
    {
        SceneManager.LoadScene(3);
    }
}
