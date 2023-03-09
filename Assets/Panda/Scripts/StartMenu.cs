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
    }
    public void CloseCredits()
    {
        CreditsMenu.SetActive(false);
    }
    public void Settings()
    {
        SettingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        SettingsMenu.SetActive(false);
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene(1);
    }
}
