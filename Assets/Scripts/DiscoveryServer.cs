using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DiscoveryServer : NetworkDiscovery
{
    public static DiscoveryServer instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        Initialize();
        StartAsServer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        StopBroadcast();
    }

    void OnReceivedBroadcast(string fromAddress, string data)
    {
        Debug.Log("\nReceived " + fromAddress + "\nData" + data);
    }
}
