using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 targetPosition;
    public float moveSpeed;
    private int power;

    Rigidbody2D myBody;
    Vector3 vecFire;

    public int Power { get => power; set => power = value; }

    // Start is called before the first frame update
    void Start()
    {
        vecFire = targetPosition - transform.position;
        if (targetPosition.x - transform.position.x <= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle(Vector3.up, vecFire));
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -1 * Vector3.Angle(Vector3.up, vecFire));
        }
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myBody.velocity = vecFire * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enemy")
        {
            Debug.Log("Button touch enemy");
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "destroyBulletPlayer")
        {
             Destroy(gameObject);
        }
    }
}
