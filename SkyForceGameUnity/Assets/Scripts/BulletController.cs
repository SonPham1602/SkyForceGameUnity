using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 targetPosition;
    public float moveSpeed = 10f;

    Rigidbody2D myBody;
    Vector3 vecFire;

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
        Destroy(gameObject, 2f);
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
    }
}
