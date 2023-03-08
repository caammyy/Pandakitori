using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIP : MonoBehaviour
{
    public void OpenScene()
    {
        PlayerPrefs.SetInt("currentLevel", levelDB.maxLevel);
        SceneManager.LoadScene(0);
    }
}
