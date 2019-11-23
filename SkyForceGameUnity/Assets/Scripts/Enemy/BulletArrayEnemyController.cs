using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletArrayEnemyController : MonoBehaviour
{
    public float speed;
    public Transform player;
    Vector3 difference;
    private Vector3 target;
     float RotationZ;
     private Vector2 screenBounds;
    private void Awake() {
        RotationZ = player.transform.rotation.z;
        Debug.Log("Vi tri player trong bullet enmey: x "+player.position.x+" y "+player.position.y);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    }
    // Start is called before the first frame update
   
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
}
