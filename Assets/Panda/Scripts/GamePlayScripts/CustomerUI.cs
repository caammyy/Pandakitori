using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text TimeRemaining;
    public Image LinearTimer;
    Customer customer;
    public bool YellowWarning;
    public bool YelloWarned;
    public bool RedWarning;
    public bool RedWarned;
    public Animator Anim;


    void Start()
    {
        customer = gameObject.GetComponent<Customer>();
        YellowWarning = false;
        YelloWarned = false;
        RedWarning = false;
        RedWarned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (customer.TimeRemaining <30) {
            LinearTimer.color = new Color32(194,226,96,255);
            Anim.SetBool("Annoyed", false);
            Anim.SetBool("Angry", false);
        }
        if (customer.TimeRemaining < 20) {
            LinearTimer.color = new Color32(255,255,17,255);
            Anim.SetBool("Annoyed", true);
        }
        if (customer.TimeRemaining < 10) {
            LinearTimer.color = new Color32(255,0,0,255);
            Anim.SetBool("Annoyed", false);
            Anim.SetBool("Angry", true);
        }
        if (customer.TimeRemaining < 20 && YelloWarned == false) {
            YellowWarning = true;
        }
        if (YellowWarning) {
            YellowWarning = false;
            YelloWarned = true;
            SoundManager.Instance.PlaySFX("YellowWarning");
        }
        if (customer.TimeRemaining <10 && RedWarned == false) {
            RedWarning = true;
        }
        if (RedWarning) {
            RedWarning = false;
            RedWarned = true;
            SoundManager.Instance.PlaySFX("RedWarning");
        }
        LinearTimer.fillAmount = customer.TimeRemaining / 30;
    }
}
