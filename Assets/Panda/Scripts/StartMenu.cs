using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] public GameObject CreditsMenu;

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
}
