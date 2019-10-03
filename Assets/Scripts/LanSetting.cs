using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanSetting : MonoBehaviour
{
    public GameObject HostUI;
    public GameObject ClientUI;
    public GameObject ButtonUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnButtonHostClick()
    {
        HostUI.active = true;
        ClientUI.active = false;
        ButtonUI.active = false;
    }

    public void OnButtonClientClick()
    {
        HostUI.active = false;
        ClientUI.active = true;
        ButtonUI.active = false;
    }

}
