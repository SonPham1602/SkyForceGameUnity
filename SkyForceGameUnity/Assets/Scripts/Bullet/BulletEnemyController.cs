using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyController : MonoBehaviour
{
    public float speed;// speed of bullet enemy
    private Transform player;
    float RotationZ;
    Vector3 difference;
    private Vector3 target;// current targer position
    // Start is called before the first frame update
    private Vector2 screenBounds;
    private int power;

    public int Power { get => power; set => power = value; }

    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y,player.position.z);
        difference = target-transform.position;
        RotationZ = Mathf.Atan2(difference.y,difference.x)*Mathf.Rad2Deg;
//        Debug.Log("Vi tri player trong bullet enmey: x "+player.position.x+" y "+player.position.y);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        Power = 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0.0f,0.0f,RotationZ-90);
        GetComponent<Rigidbody2D>().velocity = difference/difference.magnitude*speed;
        //transform.position = Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Debug.Log("Di chuyen toi vi tri");
            Destroy(this);
        }
        if(Mathf.Abs(transform.position.x)>screenBounds.x)
        {
            Destroy(this.gameObject);
        }
        else if(Mathf.Abs(transform.position.y) > screenBounds.y)
        {
            Destroy(this.gameObject);
        }
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
