using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public int levelToUnlock;
    int numberOfUnlockedLevels;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            numberOfUnlockedLevels = PlayerPrefs.GetInt("levelsunlocked");
            if(numberOfUnlockedLevels <= levelToUnlock)
            {
                PlayerPrefs.SetInt("levelsunlocked" , numberOfUnlockedLevels);
            }
        }
    }
}
