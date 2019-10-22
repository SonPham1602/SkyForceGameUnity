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
    public float Health;
    public float NumberBulletShip;
    public Sprite brokenSpriteBattleship;
    private bool isBroken;//Check enemy can shoot
    // Start is called before the first frame update
    void Start()
    {
        NumberBulletShip = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots=startTimeBtwShots; 
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwShots<=0)
        {
            if(isBroken==false)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);   
            }
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots-=Time.deltaTime;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime * 2, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="bullet")
        {
            NumberBulletShip++;
            if(NumberBulletShip==Health)
            {
                isBroken = true;
               GetComponent<SpriteRenderer>().sprite = brokenSpriteBattleship;
            }
          
        }
    }
}
