using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    static public bool ChangeLevel = false;

    static public float Level_Time_Remaining;
    public int CountDownTimer;
    public TMP_Text CountDownDisplay;
    public static bool CountDownActive = false;
    public Image Filter;
    int countdown = 10;
    bool TimesUped;

    [SerializeField] public GameObject endTransition;

    // Start is called before the first frame update
    void Start()
    {
        TimesUped = false;
        Level_Time_Remaining = 80;
        StartCoroutine(CountdownToStart());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Timer.CountDownActive == false)
        {
            if (Level_Time_Remaining > 0)
            {
                Level_Time_Remaining -= Time.deltaTime;
                if (Level_Time_Remaining < (float)countdown && countdown > 0)
                {
                    countdown--;
                    SoundManager.Instance.PlaySFX("Tick");
                }
            }
            else
            {
                StartCoroutine(TimesUp());
                if (TimesUped == false) {
                    SoundManager.Instance.PlaySFX("TimesUpBeep");
                    TimesUped = true;
                }
            }
        }

    }

    public void OpenScene()
    {
        SceneManager.LoadScene(3);
    }

    IEnumerator CountdownToStart() {
        CountDownActive = true;
        yield return new WaitForSeconds(0.2f);
        while(CountDownTimer > 0) {
            CountDownDisplay.text = CountDownTimer.ToString();
            SoundManager.Instance.PlaySFX("Beep");
            yield return new WaitForSeconds(1f);
            CountDownTimer--;
        }
        Filter.gameObject.SetActive(false);
        CountDownDisplay.text = "GO!";
        CountDownActive = false;
        yield return new WaitForSeconds(1f);
        CountDownDisplay.gameObject.SetActive(false);
    }

    IEnumerator TimesUp() {
        CountDownActive = true;
        CountDownDisplay.text = "Times Up!";
        CountDownDisplay.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        CountDownDisplay.gameObject.SetActive(false);
        CountDownActive = false;
        ChangeLevel = true;
        endTransition.SetActive(true);
        Invoke("OpenScene", 1.5f);
    }
}
