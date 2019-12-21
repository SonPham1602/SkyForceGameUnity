using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : BulletController
{
    public float Speed;
    public float RotateSpeed;
    private Rigidbody2D rb;
    private Transform target;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        Power = 20;
        //Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        distance = Vector2.Distance(transform.position, target.transform.position);
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        if (distance <= 5)
        {
           RotateSpeed=0;
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
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().HP -= Power;
            Debug.Log("HP" + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().HP);
            Destroy(gameObject);
        }
    }
}
