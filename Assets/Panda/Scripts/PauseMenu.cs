using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenuPanel;
    public static bool GameIsPaused = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        SoundManager.Instance.PlaySFX("ButtonClick");
        GameIsPaused = true;
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        SoundManager.Instance.PlaySFX("ButtonClick");
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Restart()
    {
        SoundManager.Instance.PlaySFX("ButtonClick");
        Time.timeScale = 1f;
        Debug.LogWarning(PlayerPrefs.GetInt("currentLevel"));
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
    }
    public void Home()
    {
        SoundManager.Instance.PlaySFX("ButtonClick");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
