using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyType;
    [SerializeField]
    private int numberOfEnemy = 1;
    List<GameObject> EnemyList = new  List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<numberOfEnemy;i++)
        {
            EnemyList.Add(enemyType);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
