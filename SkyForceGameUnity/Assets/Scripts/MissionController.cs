using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    [SerializeField] Toggle toggleMission1;

    [SerializeField] Toggle toggleMission2;
    
    [SerializeField] Toggle toggleMission3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetToggle(int n)
    {
        if(n == 1)
        {
            toggleMission1.Select();
        }
        else if(n == 2)
        {
            toggleMission2.Select();
        }
        else if( n == 3)
        {
            toggleMission3.Select();
        }

    }
    
}
