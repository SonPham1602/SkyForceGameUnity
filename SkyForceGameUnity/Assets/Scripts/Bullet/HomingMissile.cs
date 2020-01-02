using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeOfHomingMissile
{
    Enemy,
    Player
}

public class HomingMissile : BulletController
{
    public TypeOfHomingMissile typeOfHomingMissile;
    public AudioClip missileSound;
    public AudioSource audioSource;
    public float Speed;
    public float RotateSpeed;
    private Rigidbody2D rb;
    private GameObject target;
    private Transform targeTransform;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = missileSound;
        audioSource.Play();
        if (typeOfHomingMissile == TypeOfHomingMissile.Enemy)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("enemy");
        }

        rb = GetComponent<Rigidbody2D>();
        Power = 20;
        //Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        float rotateAmount;
        if (typeOfHomingMissile == TypeOfHomingMissile.Enemy)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            distance = Vector2.Distance(transform.position, target.transform.position);
            Vector2 direction = (Vector2)target.transform.position - rb.position;
            direction.Normalize();
            rotateAmount = Vector3.Cross(direction, transform.up).z;
            if (distance <= 5)
            {
                RotateSpeed = 0;
            }
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("enemy");
            distance = Vector2.Distance(transform.position, target.transform.position);
            Vector2 direction = (Vector2)target.transform.position - rb.position;
            direction.Normalize();
            rotateAmount = Vector3.Cross(direction, transform.up).z;

        }


        rb.angularVelocity = -rotateAmount * RotateSpeed;

        rb.velocity = transform.up * Speed;
        distance = Vector2.Distance(transform.position, target.transform.position);
        //Debug.Log(distance);


    }


    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (typeOfHomingMissile == TypeOfHomingMissile.Enemy)
        {
            if (other.gameObject.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().HP -= Power;
                Debug.Log("HP" + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().HP);
                Destroy(gameObject);
            }
        }
        else 
        {
             if (other.gameObject.tag == "enemy")
            {
                Destroy(target);
                Destroy(gameObject);
            }
        }

    }
}
