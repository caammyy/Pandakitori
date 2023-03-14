using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] public GameObject CreditsMenu;
    [SerializeField] public GameObject SettingsMenu;
    public Slider MusicSlider, SFXSlider;

    [SerializeField] public GameObject startTransition;
    [SerializeField] public GameObject endTransition;

    // Start is called before the first frame update
    void Start()
    {
        startTransition.SetActive(true);
        Invoke("startTransitionFalse", 5f);
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
        SoundManager.Instance.PlaySFX("ButtonClick");
        endTransition.SetActive(true);
        Invoke("Scene1", 1.5f);
    }
    public void Scene1()
    {
        SceneManager.LoadScene(1);
    }
    public void startTransitionFalse()
    {
        startTransition.SetActive(false);
    }
    public void ToggleMusic()
    {
        SoundManager.Instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        SoundManager.Instance.ToggleSFX();
    }
    public void MusicVolume()
    {
        SoundManager.Instance.MusicVolume(MusicSlider.value);
    }
    public void SFXVolume()
    {
        SoundManager.Instance.SFXVolume(SFXSlider.value);
    }
}
