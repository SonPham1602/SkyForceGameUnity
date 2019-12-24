﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyController : MonoBehaviour
{
    public float rotationObject;
    public GameObject turret;
    public float startTimeBtwShots;//time to shot 
    public float health;
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

    // Start is called before the first frame update
    void Start()
    {
        canShot = false;
        numberBulletTurret = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        HP = 100;
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
                    if(canShot==true)
                     Instantiate(bullet, bulletStart.transform.position, Quaternion.identity);
                    

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            HP -= other.gameObject.GetComponent<BulletController>().Power;
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
