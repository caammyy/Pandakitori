using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventory Inventory;
    public GameObject StartPos;
    public GameObject EndPos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {    
        StartCoroutine(Reset());  
    }

    IEnumerator Reset()
    {
        if (Inventory.ResetVeg && gameObject.tag == "Food2")
        {
            SoundManager.Instance.PlaySFX("ConveyerBelt");
            Debug.Log("Reset");
            transform.position = StartPos.transform.position;
            Inventory.ResetVeg = false;
            yield return StartCoroutine(Move());
        }

        if (Inventory.ResetShrimp && gameObject.tag == "Food1")
        {
            SoundManager.Instance.PlaySFX("ConveyerBelt");
            Debug.Log("Reset");
            transform.position = StartPos.transform.position;
            Inventory.ResetShrimp = false;
            yield return StartCoroutine(Move());
        }
        if (Inventory.ResetEgg && gameObject.tag == "Food3")
        {
            SoundManager.Instance.PlaySFX("ConveyerBelt");
            Debug.Log("Reset");
            transform.position = StartPos.transform.position;
            Inventory.ResetEgg = false;
            yield return StartCoroutine(Move());
        }
    }
    IEnumerator Move()
    {
        while (true)
        {
            if (Vector2.Distance(transform.position,EndPos.transform.position) < 0.05) {
                break;
            }
            transform.position = Vector3.MoveTowards(transform.position, EndPos.transform.position, 5f * Time.deltaTime);
            yield return null;
        }

    }


}
