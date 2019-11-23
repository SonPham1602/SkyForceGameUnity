using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicoperEnemy : MonoBehaviour
{
    public float speed;//speed of bullet
    public float startTimeBtwShots;
    private float timeBtwShots;
    private Transform player;
    public GameObject bullet;
    public GameObject smokeEffect;
    private bool isBroken;//Check enemy can shoot
    private float angle;
    private int hp;
    private float maxNextPosition = 0.03f;
    public int HP { get => hp; set => hp = value; }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        angle = Vector3.Angle(player.transform.position - transform.position, Vector3.right);
        if (angle < 70)
        {
            angle = 70;
        }
        timeBtwShots = startTimeBtwShots;
        HP = 10;
        smokeEffect.SetActive(false);
    }

    // Update is called once per frameS
    void Update()
    {
        if (FindObjectOfType<GameManager>().gameState != GameState.Play)
            return;
        if (timeBtwShots <= 0)
        {
            if (isBroken == false)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        if (HP > 0)
        {
            transform.parent.transform.position = new Vector3(transform.position.x + maxNextPosition, transform.position.y + Mathf.Abs(Mathf.Tan(angle)) * maxNextPosition, transform.position.z);
            angle -= 0.001f;
        }
        else
        {
            transform.parent.transform.position = new Vector3(transform.position.x + maxNextPosition, transform.position.y - 5 * maxNextPosition, transform.position.z);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet" && HP > 0)
        {
            HP -= other.gameObject.GetComponent<BulletController>().Power;
            if (HP <= 0)
            {
                gameObject.AddComponent<RotateObjectGame>();
                gameObject.GetComponent<RotateObjectGame>().speedSpin = 5;
                smokeEffect.SetActive(true);
                Destroy(gameObject, 10f);
            }
        }
    }
}
