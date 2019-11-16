﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyController : MonoBehaviour
{
    public GameObject turret;
    public float startTimeBtwShots;//time to shot 
    public float health;
    public float speedOfBullet;
    private float numberBulletTurret;
    public Sprite spriteOfBrokenTurret;
    private float timeBtwShots;
    
    private bool isBroken;
    private Transform player;
    public GameObject bullet;
    public GameObject bulletStart;
    // Start is called before the first frame update
    void Start()
    {
        numberBulletTurret = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (isBroken == false)
            {
                Instantiate(bullet, bulletStart.transform.position, Quaternion.identity);
            }
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        Vector3 difference = player.position - gameObject.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        turret.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ-90);
    }
}