using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarForPlayer : MonoBehaviour
{
    [SerializeField] AudioClip collectCoin;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float speedMoving;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = collectCoin;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(Vector3.Distance (player.position,transform.position)<=10)
        {
            Vector2 coinDirection = -(transform.position - player.position).normalized;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(coinDirection.x,coinDirection.y)*100f*(Time.deltaTime);
        }
        else 
        {
            //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.position = new Vector2(transform.position.x,transform.position.y+speedMoving*Time.deltaTime);
        }
       
       // 
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            audioSource.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled= false;
           // StartCoroutine(playSound());
            Destroy(gameObject,collectCoin.length);

            
            
        }
    }
    IEnumerator playSound()
    {
        audioSource.Play();
        yield return new WaitForSeconds(collectCoin.length);
        Destroy(gameObject);
    }

}
