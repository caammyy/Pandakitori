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
    int musindex = 0;
    int sfxindex = 0;

    [SerializeField] public GameObject startTransition;
    [SerializeField] public GameObject endTransition;

    // Start is called before the first frame update
    void Start()
    {
        startTransition.SetActive(true);
        Invoke("startTransitionFalse", 5f);
        if (!PlayerPrefs.HasKey("musicVol"))
        {
            Debug.Log("musicVol doesnt exist");
            PlayerPrefs.SetFloat("musicVol", 0.5f);
        }
        if (!PlayerPrefs.HasKey("sfxVol"))
        {
            Debug.Log("sfxVol doesnt exist");
            PlayerPrefs.SetFloat("sfxVol", 0.5f);
        }
        MusicSlider.value = PlayerPrefs.GetFloat("musicVol");
        SFXSlider.value = PlayerPrefs.GetFloat("sfxVol");
        if(PlayerPrefs.GetFloat("musicVol") == 0)
        {
            musicInc.transform.GetComponent<Image>().sprite = musicIndicator[0];
        }
        else
        {
            musindex = 1;
        }
        if (PlayerPrefs.GetFloat("sfxVol") == 0)
        {
            sfxInc.transform.GetComponent<Image>().sprite = sfxIndicator[0];
        }
        else
        {
            sfxindex = 1;
        }
        SoundManager.Instance.PlayMusic("Background");
    }

    // Update is called once per frame
    void Update()
    {
        if (musindex == 0 || PlayerPrefs.GetFloat("musicVol") == 0f)
        {
            musicInc.transform.GetComponent<Image>().sprite = musicIndicator[0];
        }
        else
        {
            musicInc.transform.GetComponent<Image>().sprite = musicIndicator[1];
        }

        if (sfxindex == 0 || PlayerPrefs.GetFloat("sfxVol") == 0f) 
        {
            sfxInc.transform.GetComponent<Image>().sprite = sfxIndicator[0];
        }
        else
        {
            sfxInc.transform.GetComponent<Image>().sprite = sfxIndicator[1];
        }
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
        if (musindex == 0)
        {
            musindex = 1;
        }
        else
        {
            musindex = 0;
        }
    }
    public void ToggleSFX()
    {
        SoundManager.Instance.ToggleSFX();
        if (sfxindex == 0)
        {
            sfxindex = 1;
        }
        else
        {
            sfxindex = 0;
        }
    }
    public void MusicVolume()
    {
        SoundManager.Instance.MusicVolume(MusicSlider.value);
        if (MusicSlider.value == 0)
        {
            musindex = 0;
        }
        else
        {
            musindex = 1;
        }
    }
    public void SFXVolume()
    {
        SoundManager.Instance.SFXVolume(SFXSlider.value);
        if (SFXSlider.value == 0)
        {
            sfxindex = 0;
        }
        else
        {
            sfxindex = 1;
        }
    }
}
