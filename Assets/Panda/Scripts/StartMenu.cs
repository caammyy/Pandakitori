using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] public GameObject CreditsMenu;
    [SerializeField] public GameObject SettingsMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Credits()
    {
        CreditsMenu.SetActive(true);
        SoundManager.Instance.PlaySFX("ButtonClick");
    }
    public void CloseCredits()
    {
        CreditsMenu.SetActive(false);
        SoundManager.Instance.PlaySFX("ButtonClick");
    }
    public void Settings()
    {
        SettingsMenu.SetActive(true);
        SoundManager.Instance.PlaySFX("ButtonClick");
    }
    public void CloseSettings()
    {
        SettingsMenu.SetActive(false);
        SoundManager.Instance.PlaySFX("ButtonClick");
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene(1);
        SoundManager.Instance.PlaySFX("ButtonClick");
    }
}
