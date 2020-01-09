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
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>() != null)
        {
            defaultValue = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().defaultHP;
        }
        else
        {
            defaultValue = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHostController>().defaultHP;
        }
        UIHeartValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindObjectOfType<PlayerController>() != null)
        {
            UIHeartValue = GameObject.FindObjectOfType<PlayerController>().hp / defaultValue;
        }
        else
        {
            UIHeartValue = GameObject.FindObjectOfType<PlayerHostController>().hp / defaultValue;
        }
        UIHeart.fillAmount = UIHeartValue;
    }
}
