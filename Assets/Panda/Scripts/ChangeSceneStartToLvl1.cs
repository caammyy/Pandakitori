using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneStartToLvl1 : MonoBehaviour
{
    public void MoveToScene()
    {
        SoundManager.Instance.PlaySFX("Start");
        if (PlayerPrefs.HasKey("currentLevel"))
        {
            SceneManager.LoadScene(2);

        }
        else
        {
            SceneManager.LoadScene(9);
        }
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void MoveToPrologue()
    {
        SoundManager.Instance.PlaySFX("ButtonClick");
        SceneManager.LoadScene(8);
    }

    public void MoveToTutorial()
    {
        SoundManager.Instance.PlaySFX("ButtonClick");
        SceneManager.LoadScene(9);
    }

}
