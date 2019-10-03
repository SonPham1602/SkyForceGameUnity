using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DiscoveryClient : NetworkDiscovery
{
    public static DiscoveryClient instance = null;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        Initialize();
    }

    public void OnStartBroatcast()
    {
        StartAsClient();
    }


    void OnDestroy()
    {
        StopBroadcast();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
