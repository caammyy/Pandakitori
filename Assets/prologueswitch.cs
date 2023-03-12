
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prologueswitch : MonoBehaviour
{

    public GameObject[] background;
    int index;
    public Button next;
    public Button play;
    public Button previous;

    void Start()
    {
        index = 0;
        play.gameObject.SetActive(false);
        previous.gameObject.SetActive(false);
    }


    void Update()
    {
        if (index >= 11)
            index = 11;

        if (index < 0)
            index = 0;



        if (index == 0)
        {
            background[0].gameObject.SetActive(true);
            previous.gameObject.SetActive(false);
        }

        if (index == 1)
        {
            previous.gameObject.SetActive(true);
        }

        if (index == 11)
        {
            next.gameObject.SetActive(false);
            play.gameObject.SetActive(true);
        }
    }

    public void Next()
    {
        index += 1;

        for (int i = 0; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }

    public void Previous()
    {
        index -= 1;

        for (int i = 0; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }


}