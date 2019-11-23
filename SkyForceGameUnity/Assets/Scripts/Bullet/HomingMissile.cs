using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float Speed;
    public float RotateSpeed;
    private Rigidbody2D rb;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate() {
        Vector2 direction = (Vector2)target.position-rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction,transform.up).z;
        rb.angularVelocity = - rotateAmount * RotateSpeed;
        rb.velocity = transform.up*Speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
