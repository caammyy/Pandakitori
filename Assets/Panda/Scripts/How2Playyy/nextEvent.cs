using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextEvent : MonoBehaviour
{
    public GameObject food;
    public GameObject customers;

    public Button play;

    public Text tutorialText;
    public Text inventoryText;

    int index;
 
    //index 0: welcome to the tutorial, WASD
    //index 1: Press E to pick up
    //index 2: Press F to clear
    //index 3: Hold and let go to shoot the stick
    //index 4: you're ready to play! feel free to continue playing.

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 0)
        {
            tutorialText.text = "Welcome to the tutorial! \n Use W, A, S, and D to move around your kitchen!";
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                index = 1;
            }
        }

        if (index == 1)
        {
            food.gameObject.SetActive(true);
            tutorialText.text = "Try adding a food piece to your Yakitori Stick! \n Move to the food piece and Press E to Pick Up!";
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Inventory.AmountOfFood > 0)
                {
                    index = 2;
                }
            }
        }
        if (index == 2)
        {
            inventoryText.gameObject.SetActive(true);
            tutorialText.text = "If you wish to remove the food from your stick, Press F to Clear!";
            if (Input.GetKeyDown(KeyCode.F))
            {
                index = 3;
            }
        }
        if (index == 3)
        {
            inventoryText.gameObject.SetActive(false);
            customers.gameObject.SetActive(true);
            tutorialText.text = "Let's serve our 1st customer! \n Follow the customer's order (above head) and PICK UP 2 food pieces! \n HOLD down your LEFT mouse button, DRAG backwards and AIM. \n Let go of the mouse button to shoot and serve!";
            if (Inventory.PlayerScore > 0)
            {
                index = 4;
            }
        }
        if (index == 4)
        {
            tutorialText.text = "You've completed the tutorial! \n When you're ready to continue, click Let's Play!";
            play.gameObject.SetActive(true);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(2);
    }
}
