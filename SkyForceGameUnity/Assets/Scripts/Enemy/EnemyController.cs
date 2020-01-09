using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LevelMapEnemy
{
    Level1,
    Level2,
    Level3,
    Level4,
    Level5,
    Level6
}
public class EnemyController : MonoBehaviour
{
    [SerializeField] bool deleteSpriteWhenDead;
    public LevelMapEnemy levelMapEnemy;
    public bool ShowInCamera;// check co xuat hien tren camera ko
    public AudioClip soundExplosion;
    public AudioSource audioSourceExplosion;
    public int ScoreTake;// Quy dinh bao nhieu diem khi tieu diet enemy
    public float gravity = 20.0f;
    // public float speed = 6.0f;
    protected Rigidbody2D rigidbody2d;
    //public Anchor_Plane anchor;
    //public TypePath typePath;
    //public bool fly_up;
    public float speedTurn;
    protected float offset;
    public float speedMove;
    protected GameManager _gameManager;
    protected Vector2 saveScale;
    public bool canMove;
    public Color color;
    public GameObject starItem;
    public GameObject explostionEffect;


    // Start is called before the first frame update
    Vector2 screenBounds;

    public float HP;
    private bool isAlive;



    protected void Start()
    {
        isAlive = true;

        //Controller Heal defend on level
        ControllerLevelEnemyHealth();
        offset = Time.deltaTime * speedMove;
        rigidbody2d = GetComponent<Rigidbody2D>();
        saveScale = transform.localScale;
        _gameManager = FindObjectOfType<GameManager>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    protected void Update()
    {
        if (Mathf.Abs(transform.position.x) > screenBounds.x + 10)
        {
            Destroy(this.gameObject);
        }
        else if (Mathf.Abs(transform.position.y) > screenBounds.y + 10)
        {
            Destroy(this.gameObject);
        }
        //transform.Translate(0,1*Time.deltaTime,0);
    }

    // protected void FixedUpdate()
    // {
    //     offset = Time.deltaTime * speedMove;
    //     if (canMove == true)
    //     {
    //         Move();
    //     }

    // }
    protected void PlayExplosionSound()
    {
        audioSourceExplosion.clip = soundExplosion;
        audioSourceExplosion.Play();
    }
    protected void OnTriggerBulletEnter(GameObject other)
    {
        StartCoroutine(getHit());
        HP -= other.gameObject.GetComponent<BulletController>().Power;
        if (HP <= 0 && isAlive == true)
        {
            if (deleteSpriteWhenDead == true)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            }
            isAlive = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            GameSetting.ScoreGame += ScoreTake;
            PlayExplosionSound();
            Instantiate(starItem, transform.position, Quaternion.identity);
            //StartCoroutine(PlayExplosion());


            Instantiate(explostionEffect, transform.position, Quaternion.identity);

        }
    }
    // IEnumerator PlayExplosion()
    // {
    //     audioSourceExplosion.Play();
    //     yield return new WaitWhile(()=>audioSourceExplosion.isPlaying);
    // }
    void ControllerLevelEnemyHealth()
    {
        if (levelMapEnemy == LevelMapEnemy.Level2)
        {
            HP += 100;
        }
        else if (levelMapEnemy == LevelMapEnemy.Level3)
        {
            HP += 150;
        }
        else if (levelMapEnemy == LevelMapEnemy.Level4)
        {
            HP += 175;
        }
        else if (levelMapEnemy == LevelMapEnemy.Level5)
        {
            HP += 200;
        }
        else if (levelMapEnemy == LevelMapEnemy.Level6)
        {
            HP += 250;
        }
    }
    protected void OnTriggerPlayerEnter(GameObject other)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().HP -= 20;
        Instantiate(explostionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "bullet")
    //     {
    //         OnTriggerBulletEnter(other.gameObject);
    //         gameObject.GetComponent<ControllerTrailEnemy>().DestroyTrailOfEnemy();
    //         Destroy(gameObject,soundExplosion.length+0.5f);
    //     }
    //     else if (other.gameObject.tag == "Player")
    //     {
    //         OnTriggerPlayerEnter(other.gameObject);
    //     }
    // }
    protected IEnumerator getHit()
    {
        Debug.Log("Get hit");
        StopCoroutine("getHit");
        SpriteRenderer sr = transform.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            color = Color.red;
            sr.color = color;
            yield return new WaitForSeconds(0.1f);
            color = Color.white;
            sr.color = color;
        }
    }
    // public void Move()
    // {
    //     int direc;
    //     if (fly_up)
    //     {
    //         direc = -1;
    //     }
    //     else
    //     {
    //         direc = 1;
    //     }

    //     if (typePath == TypePath.curve_up)
    //     {
    //         transform.localScale = new Vector3(direc * saveScale.x, saveScale.y, 0);
    //         transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.eulerAngles.z - speedTurn));
    //         transform.position += direc * transform.right * offset;
    //     }
    //     if (typePath == TypePath.curve_down)
    //     {
    //         transform.localScale = new Vector3(-direc * saveScale.x, saveScale.y, 0);
    //         transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.eulerAngles.z + speedTurn));
    //         transform.position -= direc * transform.right * offset;
    //     }
    //     if (typePath == TypePath.line)
    //     {
    //         if (anchor == Anchor_Plane.top)
    //         {
    //             //transform.localScale = new Vector3(direc*saveScale.x,saveScale.y,0);
    //             transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -90));
    //             transform.position += transform.right * offset;
    //         }
    //         else if (anchor == Anchor_Plane.right)
    //         {
    //             //transform.localScale = new Vector3(saveScale.x, saveScale.y, 0);
    //             transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
    //             transform.position += transform.right * offset;
    //         }
    //         else if (anchor == Anchor_Plane.left)
    //         {
    //             // transform.localScale = new Vector3(saveScale.x, saveScale.y, 0);
    //             transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    //             transform.position += transform.right * offset;
    //         }
    //         else if (anchor == Anchor_Plane.top_left)
    //         {
    //             //transform.localScale = new Vector3(direc * saveScale.x, saveScale.y, 0);
    //             transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -60));
    //             transform.position += transform.right * offset;
    //         }
    //         else if (anchor == Anchor_Plane.top_right)
    //         {
    //             //transform.localScale = new Vector3(direc * saveScale.x,saveScale.y,0);
    //             transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -120));
    //             transform.position += transform.right * offset;
    //         }
    //     }
    // }
}
