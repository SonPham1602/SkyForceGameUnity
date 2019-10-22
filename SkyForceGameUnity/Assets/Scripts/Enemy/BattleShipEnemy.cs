using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShipEnemy : MonoBehaviour
{
    public float speed;//speed of bullet
    public float startTimeBtwShots;
    private bool stopPoint;
    private float timeBtwShots;
    private Transform player;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots=startTimeBtwShots; 
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwShots<=0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots-=Time.deltaTime;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime * 2, transform.position.z);
    }
}
