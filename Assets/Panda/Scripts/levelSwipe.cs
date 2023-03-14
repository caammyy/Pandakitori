using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSwipe : MonoBehaviour
{
    public Sprite[] background;
    public GameObject scrollbar, bgObject, locked, go;
    private float scroll_pos = 0;
    float[] pos;
    private bool runIt = false;
    private float time;

    public Text lvl1, lvl2, lvl3;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlaySFX("ButtonClick");
        if (!PlayerPrefs.HasKey("currentLevel"))
        {
            PlayerPrefs.SetInt("currentLevel", 5);
        }
        if (!PlayerPrefs.HasKey("levelsunlocked"))
        {
            PlayerPrefs.SetInt("levelsunlocked", 5);
        }
        if (PlayerPrefs.HasKey("Level1_HS"))
        {
            lvl1.text = PlayerPrefs.GetInt("Level1_HS").ToString();
        }
        if (PlayerPrefs.HasKey("Level2_HS"))
        {
            lvl2.text = PlayerPrefs.GetInt("Level2_HS").ToString();
        }
        if (PlayerPrefs.HasKey("Level3_HS"))
        {
            lvl3.text = PlayerPrefs.GetInt("Level3_HS").ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        if (runIt)
        {
            time += Time.deltaTime;

            if (time > 1f)
            {
                time = 0;
                runIt = false;
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }


        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                //Debug.LogWarning(i);
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                bgObject.transform.GetComponent<Image>().sprite = background[i];
                PlayerPrefs.SetInt("currentLevel", i+5);
                if (PlayerPrefs.GetInt("currentLevel") > PlayerPrefs.GetInt("levelsunlocked"))
                {
                    locked.SetActive(true);
                    go.SetActive(false);
                }
                else
                {
                    locked.SetActive(false);
                    go.SetActive(true);
                }
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }


    }

}