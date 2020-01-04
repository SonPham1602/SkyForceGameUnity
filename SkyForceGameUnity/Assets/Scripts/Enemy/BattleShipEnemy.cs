using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleShipEnemy : MonoBehaviour
{
    public float speedRotation;
    public float speed;//speed of bullet
    public float startTimeBtwShots;
    private bool stopPoint;
    private float timeBtwShots;
    private Transform player;
    public GameObject bullet;
    public float Health;
    private float NumberBulletShip;
    public Sprite brokenSpriteBattleship;
    public GameObject turret;
    public GameObject startFire;
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
                Instantiate(bullet, startFire.transform.position, Quaternion.identity);   
            }
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots-=Time.deltaTime;
        }
        Vector3 difference = player.position-gameObject.transform.position;
        float rotationZ = Mathf.Atan2(difference.y,difference.x)*Mathf.Rad2Deg;
//        Debug.Log(rotationZ);
        turret.transform.rotation=Quaternion.Euler(0.0f,0.0f,rotationZ+90);
        if(isBroken==true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 2*speed * Time.deltaTime, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="bullet")
        {
            NumberBulletShip++;
            if(NumberBulletShip==Health)
            {
                isBroken = true;
                GetComponent<SpriteRenderer>().sprite = brokenSpriteBattleship;
                this.gameObject.tag="brokenEnemy";
                turret.SetActive(false);      
            }
            
          
        }
    }
}
