using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBarController : MonoBehaviour
{
    [SerializeField] GameObject mission1;
    [SerializeField] GameObject mission2;
    [SerializeField] GameObject mission3;
    [SerializeField] Sprite missionfail1;
    [SerializeField] Sprite missionfail2;

    [SerializeField] Sprite missionfail3;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetFailMission(int i)
    {
        if(i==1)
        {
            mission1.GetComponent<Image>().sprite = missionfail1;
        }
        else if(i==2)
        {
            mission2.GetComponent<Image>().sprite = missionfail2;
        }
        else if(i==3)
        {
            mission3.GetComponent<Image>().sprite = missionfail3;
        }
    }
}
