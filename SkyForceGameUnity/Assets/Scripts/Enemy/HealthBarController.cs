using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] EnemyController enemyController;
    [SerializeField] GameObject bar;
    [SerializeField] GameObject health;

    float valueHealth;
    float divisor;
    // Start is called before the first frame update
    void Start()
    {

        divisor = enemyController.HP;
        valueHealth = enemyController.HP;

    }

    // Update is called once per frame
    void Update()
    {
       
        Debug.Log("mau cau turret" + enemyController.HP);
        valueHealth = enemyController.HP;
        if (valueHealth <= 0)
        {
            health.transform.localScale = new Vector3(0, 1, 1);
        }
        else
        {
            health.transform.localScale = new Vector3(valueHealth / divisor, 1, 1);
        }

        Debug.Log("Local Scale " + health.transform.localScale.x);

    }

}
