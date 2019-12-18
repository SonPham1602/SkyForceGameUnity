using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointEventMapGameController : MonoBehaviour
{
    [SerializeField] GameObject listEnemyOfMap;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Debug.Log("hello");


    }
    private void Update()
    {

    }
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        string tagObject = other.gameObject.tag;
        Debug.Log(tagObject);
        if (other.gameObject.tag == "FightBoss")
        {
            Debug.Log("Dung map");
            listEnemyOfMap.GetComponent<ControllerListEnemy>().StopMovingListEnemy();
        }
    }
}
