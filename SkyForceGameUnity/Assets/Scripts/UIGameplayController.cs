using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplayController : MonoBehaviour
{
    [SerializeField] Image UIHeart;
    [SerializeField] [Range(0,1)] float UIHeartValue;
    // Start is called before the first frame update
    void Start()
    {
        UIHeartValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
         UIHeartValue = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().hp/100;
         UIHeart.fillAmount = UIHeartValue;
         
    }
}
