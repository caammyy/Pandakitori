using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelButton : MonoBehaviour
{
    public void OpenScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
    }
}
