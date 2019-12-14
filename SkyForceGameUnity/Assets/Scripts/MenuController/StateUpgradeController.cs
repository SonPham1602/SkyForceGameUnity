using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateUpgradeController : MonoBehaviour
{

    public int numberOfState;
    public GameObject[] scoreOfState;
    // Start is called before the first frame update
    void Start()
    {
            for (int i = 0; i < numberOfState; i++)
            {
                scoreOfState[i].gameObject.GetComponent<UpgradePlayerController>().UpItem();
            }
            for (int i = numberOfState; i < 5; i++)
            {
                scoreOfState[i].gameObject.GetComponent<UpgradePlayerController>().DownItem();
            }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpState()
    {
        if (numberOfState < 5)
        {
            numberOfState++;
            for (int i = 0; i < numberOfState; i++)
            {
                scoreOfState[i].gameObject.GetComponent<UpgradePlayerController>().UpItem();
            }
            for (int i = numberOfState; i < 5; i++)
            {
                scoreOfState[i].gameObject.GetComponent<UpgradePlayerController>().DownItem();
            }
        }
    }
}
