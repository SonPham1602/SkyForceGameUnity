using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleShipEnemy : EnemyController
{
    [SerializeField] AudioClip soundTurret;
    public float speedRotation;
    public float speed;//speed of bullet
    public float startTimeBtwShots;
    private bool stopPoint;
    private float timeBtwShots;
    private GameObject player;
    public GameObject bullet;
    private float NumberBulletShip;
    public Sprite brokenSpriteBattleship;
    public GameObject turret;
    public GameObject startFire;
    public bool canShot;
    private bool isBroken;//Check enemy can shoot
    // Start is called before the first frame update
    void Start()
    {
        NumberBulletShip = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (isBroken == false)
            {
                if (canShot == true)
                {
                    audioSourceExplosion.clip = soundTurret;
                    audioSourceExplosion.Play();
                    Instantiate(bullet, startFire.transform.position, Quaternion.identity);
                }

            }
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        Vector3 difference = player.transform.position - gameObject.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //        Debug.Log(rotationZ);
        turret.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90);
        if (isBroken == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 2 * speed * Time.deltaTime, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }

    }
    public void EnableTurret()
    {
        canShot = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            StartCoroutine(getHit());
            HP -= other.gameObject.GetComponent<BulletController>().Power;
            if (HP <= 0)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                GameSetting.ScoreGame += ScoreTake;
                PlayExplosionSound();
                Instantiate(starItem, transform.position, Quaternion.identity);
                GetComponent<SpriteRenderer>().sprite = brokenSpriteBattleship;


                this.gameObject.tag = "brokenEnemy";
                turret.SetActive(false);
                //StartCoroutine(PlayExplosion());
                Instantiate(explostionEffect, transform.position, Quaternion.identity);
                isBroken = true;

            }



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
}
