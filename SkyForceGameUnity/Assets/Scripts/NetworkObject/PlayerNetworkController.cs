﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkController : PlayerController
{
    struct BulletPos
    {
        public Vector2 pos1;
        public Vector2 pos2;
    };

    struct ValueEquation
    {
        public float x1;
        public float x2;
    };


    private List<Vector3> newPositions;

    public static PlayerNetworkController Instance{get; set;}
    public Player user;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        newPositions = new List<Vector3>();
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (newPositions.Count > 0)
        {
            Vector3 newPos = newPositions[0];
            rb.MovePosition(new Vector2(newPos.x, newPos.y));
            newPositions.Remove(newPos);
        }
    }
    public void AddNewPosition(Vector3 newPos)
    {
        newPositions.Add(newPos);
    }

    public void ShotBullet()
    {
        CreateOneBullet(target.transform.position, bullet, 15);
        audioSource.clip = shootBulletSound;
        audioSource.Play();
    }

}
