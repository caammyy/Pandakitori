using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelUnlock : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    int unlockedLevels;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("levelsunlocked"))
        {
            PlayerPrefs.SetInt("levelsunlocked", 1);
        }
        unlockedLevels = PlayerPrefs.GetInt("levelsunlocked");
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }
    private void Update()
    {
        unlockedLevels = PlayerPrefs.GetInt("levelsunlocked");
        for (int i = 0; i < unlockedLevels; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
