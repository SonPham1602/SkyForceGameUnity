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
        if (GameObject.FindObjectOfType<OnlineGameManager>() != null)
        {
            defaultValue = GameObject.FindObjectOfType<PlayerController>().defaultHP;
        }
        else
        {
            defaultValue = GameObject.FindObjectOfType<PlayerHostController>().defaultHP;
        }
        UIHeartValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindObjectOfType<GameManager>() != null)
        {
            Debug.Log(UIHeartValue);
            UIHeartValue = GameObject.FindObjectOfType<PlayerController>().hp / defaultValue;
        }
        else
        {
            UIHeartValue = GameObject.FindObjectOfType<PlayerHostController>().hp / defaultValue;
        }
        UIHeart.fillAmount = UIHeartValue;
    }
}
