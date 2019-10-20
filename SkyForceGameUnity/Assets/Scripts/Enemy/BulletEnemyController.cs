using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyController : MonoBehaviour
{
    public float speed;// speed of bullet enemy
    private Transform player;
    private Vector2 target;// current targer position
    // Start is called before the first frame update
    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target= new Vector2(player.position.x,player.position.y);
        Debug.Log("Vi tri player trong bullet enmey: x "+player.position.x+" y "+player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Debug.Log("Di chuyen toi vi tri");
        }
    }
}
