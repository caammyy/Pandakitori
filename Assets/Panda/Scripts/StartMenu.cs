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
    public GameObject musicInc;
    public GameObject sfxInc;
    public Sprite[] musicIndicator;
    public Sprite[] sfxIndicator;

    [SerializeField] public GameObject startTransition;
    [SerializeField] public GameObject endTransition;

    // Start is called before the first frame update
    void Start()
    {
        startTransition.SetActive(true);
        Invoke("startTransitionFalse", 5f);

        MusicSlider.value = PlayerPrefs.GetFloat("musicVol");
        SFXSlider.value = PlayerPrefs.GetFloat("sfxVol");
        if(PlayerPrefs.GetFloat("musicVol") == 0)
        {
            musicInc.transform.GetComponent<Image>().sprite = musicIndicator[1];
        }
        if (PlayerPrefs.GetFloat("sfxVol") == 0)
        {
            sfxInc.transform.GetComponent<Image>().sprite = sfxIndicator[1];
        }
        SoundManager.Instance.PlayMusic("Background");
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
        //if (musicInc.sprite == musicIndicator[1])
        //{
        //    musicInc.transform.GetComponent<Image>().sprite == musicIndicator[0];
        //}
        //else
        //{
        //    musicInc.transform.GetComponent<Image>().sprite == musicIndicator[1];
        //}
    }
    public void ToggleSFX()
    {
        SoundManager.Instance.ToggleSFX();
        //if (sfxInc.sprite == sfxIndicator[1])
        //{
        //    sfxInc.transform.GetComponent<Image>().sprite == sfxIndicator[0];
        //}
        //else
        //{
        //    sfxInc.transform.GetComponent<Image>().sprite == sfxIndicator[1];
        //}
    }
    public void MusicVolume()
    {
        SoundManager.Instance.MusicVolume(MusicSlider.value);
        //if (MusicSlider.value == 0)
        //{
        //    musicInc.transform.GetComponent<Image>().sprite == musicIndicator[1];
        //}
        //else
        //{
        //    musicInc.transform.GetComponent<Image>().sprite == musicIndicator[0];

        //}
    }
    public void SFXVolume()
    {
        SoundManager.Instance.SFXVolume(SFXSlider.value);
        //if (SFXSlider.value == 0)
        //{
        //    sfxInc.transform.GetComponent<Image>().sprite == sfxIndicator[1];
        //}
        //else
        //{
        //    sfxInc.transform.GetComponent<Image>().sprite == sfxIndicator[0];
        //}
    }
}
