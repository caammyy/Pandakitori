using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class goNextLevel : MonoBehaviour
{
    public void OpenScene()
    {
        Debug.LogWarning(PlayerPrefs.GetInt("currentLevel"));
        //PlayerPrefs.SetInt("currentLevel", 4);
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
    }
}
