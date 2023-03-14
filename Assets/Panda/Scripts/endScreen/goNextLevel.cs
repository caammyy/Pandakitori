using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class goNextLevel : MonoBehaviour
{
    [SerializeField] public GameObject endTransition;

    public void OpenScene()
    {
        endTransition.SetActive(true);
        Invoke("currentScene", 1.5f);
    }
    public void currentScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
    }
}
