using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Background");
        if (PlayerPrefs.HasKey("musicVol"))
        {
            MusicVolume(PlayerPrefs.GetFloat("musicVol"));
        }
        if (PlayerPrefs.HasKey("sfxVol"))
        {
            SFXVolume(PlayerPrefs.GetFloat("sfxVol"));
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if(s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
            if (PlayerPrefs.HasKey("musicVol"))
            {
                Debug.Log("has music volume preset");
                MusicVolume(PlayerPrefs.GetFloat("musicVol"));
            }
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
    
    public void ToggleMusic(float musvolume)
    {
        if (musvolume > 0 && musicSource.volume != 0)
        {
            musicSource.volume = 0;
        }
        else
        {
            musicSource.volume = musvolume;
        }
        PlayerPrefs.SetFloat("musicVol", musvolume);

        //musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX(float sfxvolume)
    {
        if (sfxvolume > 0 && sfxSource.volume != 0)
        {
            sfxSource.volume = 0;
        }
        else
        {
            sfxSource.volume = sfxvolume;
        }
        PlayerPrefs.SetFloat("sfxVol", sfxvolume);

        //sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float musvolume)
    {
        musicSource.volume = musvolume;
        PlayerPrefs.SetFloat("musicVol", musvolume);
    }
    public void SFXVolume(float sfxvolume)
    {
        sfxSource.volume = sfxvolume;
        PlayerPrefs.SetFloat("sfxVol", sfxvolume);
    }
}
