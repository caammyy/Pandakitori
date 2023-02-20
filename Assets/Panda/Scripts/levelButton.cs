using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelButton : MonoBehaviour
{
    public void OpenScene()
    {
        Debug.LogWarning(PlayerPrefs.GetInt("levelsunlocked"));
        Debug.LogWarning(PlayerPrefs.GetInt("currentLevel"));
        if (PlayerPrefs.GetInt("levelsunlocked") >= PlayerPrefs.GetInt("currentLevel"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
        }
    }
}
