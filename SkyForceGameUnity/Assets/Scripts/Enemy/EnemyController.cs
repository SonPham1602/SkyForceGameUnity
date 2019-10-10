using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float gravity = 20.0f;
   // public float speed = 6.0f;
    public float heal = 100f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       //transform.Translate(0,1*Time.deltaTime,0);
    }
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Dan");
        if(other.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
}
