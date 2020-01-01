using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyController : MonoBehaviour
{
    public bool numberOfBulletInOneTurn;
    public float rotationObject;
    public GameObject turret;
    public float startTimeBtwShots;//time to shot 
    public float speedOfBullet;
    private float numberBulletTurret;
    public Sprite spriteOfBrokenTurret;
    private float timeBtwShots;
    private float timeStart;
    public float timeToStartShoot;

    private bool isBroken;
    private Transform player;

    public GameObject bullet;
    public GameObject bulletStart;
    public bool canShot;

    private int hp;

    public int HP { get => hp; set => hp = value; }
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        canShot = false;
        numberBulletTurret = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        HP = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToStartShoot <= timeStart)
        {
            if (timeBtwShots <= 0)
            {
                if (isBroken == false)
                {
                    if (canShot == true)
                    {
                        if (numberOfBulletInOneTurn == false)
                        {
                            Instantiate(bullet, bulletStart.transform.position, Quaternion.identity);
                        }
                        else
                        {
                            
                        //     int numberBullet = 4;
                        //     float timeShoot = 0.5f;
                        //    Debug.Log(timeShoot);
                        //     while (numberBullet <= 0)
                        //     {
                        //         if (timeShoot <= 0 && numberBullet >= 0)
                        //         {
                        //             Instantiate(bullet, bulletStart.transform.position, Quaternion.identity);
                        //             timeShoot=0.5f;
                        //             numberBullet--;
                        //         }
                        //          timeShoot -= Time.deltaTime;
                        //     }
                        StartCoroutine(shot());
                        }




                    }



                }
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        else
        {
            timeStart += Time.deltaTime;
        }



        Vector3 difference = player.position - gameObject.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        turret.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - rotationObject);
    }
    IEnumerator shot()
    {
        for(int i=0;i<5;i++)
        {
               Instantiate(bullet, bulletStart.transform.position, Quaternion.identity);
               yield return new WaitForSeconds(0.1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            StartCoroutine(getHit());
            HP -= other.gameObject.GetComponent<BulletController>().Power;
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.tag == "enableEnemy")
        {
            canShot = true;
        }
    }
    IEnumerator getHit()
    {
        Debug.Log("Get hit");
        StopCoroutine("getHit");
        SpriteRenderer sr = transform.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            color = Color.red;
            sr.color = color;
            yield return new WaitForSeconds(0.1f);
            color = Color.white;
            sr.color = color;
        }
    }
    public void EnableTurret()
    {
        canShot = true;
    }
}
