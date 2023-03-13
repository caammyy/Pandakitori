
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageswitch : MonoBehaviour
{

    public GameObject[] background;
    int index;
    public Button next;
    public Button play;
    public Button skip;
    public Button previous;

    void Start()
    {
        index = 0;
        play.gameObject.SetActive(false);
        previous.gameObject.SetActive(false);
        skip.gameObject.SetActive(true);
    }


    void Update()
    {

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

        if (index == (background.Length - 1))
        {
            next.gameObject.SetActive(false);
            play.gameObject.SetActive(true);
            skip.gameObject.SetActive(false);
        }
    }

    public void Next()
    {
        SoundManager.Instance.PlaySFX("ButtonClick");
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
        SoundManager.Instance.PlaySFX("ButtonBack");
        index -= 1;

        for (int i = 0; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }


}