﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicoperEnemy : FlyingEnemyController
{
    public AudioClip soundFlyHelicoper;
    public AudioSource audioSource;

    public float speedBullet;//speed of bullet
    public float startTimeBtwShots;
    private float timeBtwShots;
    private Transform player;
    public GameObject bullet;
    public GameObject smokeEffect;
    private bool isBroken;//Check enemy can shoot
    private float angle;
    private float maxNextPosition = 0.03f;

    private bool shooted;
    [SerializeField] GameObject wingHelocoper;

    // Start is called before the first frame update
    void Start()
    {
        // Play sound Moving
        audioSource.clip = soundFlyHelicoper;
        audioSource.Play();
        HP = 100;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        angle = Vector3.Angle(player.transform.position - transform.position, Vector3.right);
        if (angle < 70)
        {
            angle = 70;
        }
        timeBtwShots = startTimeBtwShots;
        HP = 100;
        smokeEffect.SetActive(false);
    }

    // Update is called once per frameS
    void Update()
    {
        if ((FindObjectOfType<GameManager>() != null && FindObjectOfType<GameManager>().gameState != GameState.Play) ||
        (FindObjectOfType<OnlineGameManager>() != null && FindObjectOfType<OnlineGameManager>().gameState != GameState.Play))
            return;
        if (timeBtwShots <= 0 && shooted == false && canMove == true)
        {

            if (isBroken == false)
            {

                //Debug.Log("Ten lua");
                Instantiate(bullet, transform.position, Quaternion.identity);
                shooted = true;
            }
            //timeBtwShots = startTimeBtwShots;
        }
        else if (canMove == true)
        {
            timeBtwShots -= Time.deltaTime;
        }
        if (HP > 0)
        {
            //transform.transform.position = new Vector3(transform.position.x + maxNextPosition, transform.position.y + Mathf.Abs(Mathf.Tan(angle)) * maxNextPosition, transform.position.z);
            angle -= 0.001f;
        }
        else
        {
            isBroken = true;
            //transform.transform.position = new Vector3(transform.position.x + maxNextPosition, transform.position.y - 5 * maxNextPosition, transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("On aaa");
        if (other.gameObject.tag == "Player")
        {
            OnTriggerPlayerEnter(other.gameObject);
        }
        if (other.gameObject.tag == "destroyEnemy")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "bullet")
        {
            //OnTriggerBulletEnter(other.gameObject);
            HP -= other.gameObject.GetComponent<BulletController>().Power;
            StartCoroutine(getHit());
            if (HP <= 0)
            {
                GameObject.FindObjectOfType<CameraShakingController>().ShakeIt();
                Instantiate(explostionEffect,transform.position,Quaternion.identity);
                gameObject.GetComponent<SpriteRenderer>().enabled =false;
                gameObject.GetComponent<PolygonCollider2D>().enabled=false;
                wingHelocoper.GetComponent<SpriteRenderer>().enabled = false;
                // gameObject.AddComponent<RotateObjectGame>();
                // gameObject.GetComponent<RotateObjectGame>().speedSpin = 5;
                //smokeEffect.SetActive(true);
                //Destroy(wingHelocoper);
                Destroy(gameObject, 0.5f);

            }
        }

    }


    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "bullet" && HP > 0)
    //     {
    //         HP -= other.gameObject.GetComponent<BulletController>().Power;
    //         if (HP <= 0)
    //         {
    //             gameObject.AddComponent<RotateObjectGame>();
    //             gameObject.GetComponent<RotateObjectGame>().speedSpin = 5;
    //             smokeEffect.SetActive(true);
    //             Destroy(gameObject, 10f);
    //         }
    //     }
    // }
}
