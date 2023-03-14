using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelButton : MonoBehaviour
{
    [SerializeField] public GameObject endTransition;

    public void OpenScene()
    {
        SoundManager.Instance.PlaySFX("Start");
        if (PlayerPrefs.GetInt("levelsunlocked") >= PlayerPrefs.GetInt("currentLevel"))
        {
            endTransition.SetActive(true);
            Invoke("currentScene", 1.5f);
        }
    }
    public void currentScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
    }
}
