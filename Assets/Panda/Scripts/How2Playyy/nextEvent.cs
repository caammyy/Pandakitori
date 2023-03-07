using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextEvent : MonoBehaviour
{
    public GameObject food;
    public GameObject customers;

    public Button previous;
    public Button next;
    public Button play;

    public Text tutorialText;

    int index;

    //index 0: welcome to the tutorial
    //index 1: WASD
    //index 2: Press E to pick up
    //index 3: Press F to clear
    //index 4: Hold and let go to shoot the stick
    //index 5: you're ready to play! feel free to continue playing.

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        play.gameObject.SetActive(false);
        previous.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (index >= 5)
            index = 5;

        if (index < 0)
            index = 0;



        if (index == 0)
        {
            customers.gameObject.SetActive(false);
            food.gameObject.SetActive(false);
            previous.gameObject.SetActive(false);
            tutorialText.text = "Welcome to the tutorial! Click Next to continue.";
        }

        if (index == 1)
        {
            customers.gameObject.SetActive(false);
            previous.gameObject.SetActive(true);
            food.gameObject.SetActive(false);
            tutorialText.text = "You may use W, A, S, and D to move around your kitchen.";
        }
        else if (index == 2)
        {
            customers.gameObject.SetActive(false);
            food.gameObject.SetActive(true);
            tutorialText.text = "Try picking up a piece of food to add to your Yakitori Stick! Press E to Pick Up.";
        }
        else if (index == 3)
        {
            customers.gameObject.SetActive(false);
            tutorialText.text = "If you wish to remove the food from your stick, Press F to Clear.";
        }
        else if (index == 4)
        {
            customers.gameObject.SetActive(true);
            tutorialText.text = "Let's try serving our 1st customer! Pick up a full stick of food! Then, hold down your LEFT mouse button and drag backwards and aim for the customer. Let go of your mouse button to shoot!";
        }
        else if (index == 5)
        {
            tutorialText.text = "You're ready to play! When you're ready, click Let's Play!";
            next.gameObject.SetActive(false);
            play.gameObject.SetActive(true);
        }
    }
    public void Next()
    {
        index += 1;

    }
    public void Previous()
    {
        index -= 1;
    }
    public void Play()
    {
        SceneManager.LoadScene(2);
    }
}
