using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyController : EnemyController
{
    [SerializeField] AudioClip turretSoundShot;
    [SerializeField] AudioSource audioSource;
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

    public bool isBroken;
    private GameObject player;

    public GameObject bullet;
    public GameObject bulletStart;
    public bool canShot;

    public bool bulletShooted;


    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = turretSoundShot;
        canShot = false;
        numberBulletTurret = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        timeBtwShots = startTimeBtwShots;
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
                            audioSource.Play();
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
                            audioSource.Play();
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



        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        Vector3 difference = player.transform.position - gameObject.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if (isBroken == false)
        {
            turret.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - rotationObject);
        }
        else
        {
            turret.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationObject);
        }

    }
    IEnumerator shot()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(bullet, bulletStart.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator setBulletCheckTouch()
    {
        bulletShooted = false;
        yield return new WaitForSeconds(2);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            bulletShooted = true;
            StartCoroutine(setBulletCheckTouch());
            StartCoroutine(getHit());
            HP -= other.gameObject.GetComponent<BulletController>().Power;
            if (HP <= 0)
            {
                Instantiate(explostionEffect, transform.position, Quaternion.identity);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                isBroken = true;
                canShot = false;

                //Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "enableEnemy")
        {
            canShot = true;
        }
        else if (other.gameObject.tag == "destroyEnemy")
        {
            Destroy(gameObject);
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
