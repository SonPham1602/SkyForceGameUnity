using System.Collections;
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

    public static PlayerNetworkController Instance { get; set; }
    public Player user;

  

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        newPositions = new List<Vector3>();
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.fixedAngle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (newPositions.Count > 0)
        {
            Vector3 newPos = newPositions[0];
            if (newPos.z == 0f)
            {
                rb.MovePosition(new Vector2(newPos.x, newPos.y));
            }
            else if (newPos.z == 1f) // shot bullet
            {
                ShotBullet();
            }
            newPositions.Remove(newPos);
        }
    }
    public void AddNewPosition(Vector3 newPos)
    {
        newPositions.Add(new Vector3(newPos.x, newPos.y, 0));
    }

    public void AddNewShotBullet()
    {
        newPositions.Add(new Vector3(0, 0, 1));
    }

    public void ShotBullet()
    {
        CreateOneBullet(target.transform.position, bullet1, 15,startShot);
        audioSource.clip = shootBulletSound;
        audioSource.Play();
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        
    }

}
