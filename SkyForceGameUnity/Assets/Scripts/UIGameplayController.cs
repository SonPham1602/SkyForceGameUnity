using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplayController : MonoBehaviour
{
    [SerializeField] Image UIHeart;
    [SerializeField] [Range(0, 1)] float UIHeartValue;
    float defaultValue;
    // Start is called before the first frame update
    void Start()
    {
       
        UIHeartValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
         defaultValue = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().defaultHP;
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>() != null)
        {
            UIHeartValue = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().hp / defaultValue;
        }
        else
        {
            UIHeartValue = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHostController>().hp / defaultValue;
        }
        UIHeart.fillAmount = UIHeartValue;
    }
}
