using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int ScoreTake;// Quy dinh bao nhieu diem khi tieu diet enemy
    public float gravity = 20.0f;
    // public float speed = 6.0f;
    protected Rigidbody2D rigidbody2d;
    public Anchor_Plane anchor;
    public TypePath typePath;
    public bool fly_up;
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

    public float HP { get; set; }

    void Start()
    {
        offset = Time.deltaTime * speedMove;
        rigidbody2d = GetComponent<Rigidbody2D>();
        saveScale = transform.localScale;
        _gameManager = FindObjectOfType<GameManager>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        HP = 10;
    }

    // Update is called once per frame
    void Update()
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
    protected void FixedUpdate()
    {
        offset = Time.deltaTime * speedMove;
        if (canMove == true)
        {
            Move();
        }

    }
    protected void OnTriggerBulletEnter(GameObject other)
    {
        StartCoroutine(getHit());
        HP -= other.gameObject.GetComponent<BulletController>().Power;
        if (HP <= 0)
        {
            GameSetting.ScoreGame += ScoreTake;
            Instantiate(explostionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    protected void OnTriggerPlayerEnter(GameObject other)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().HP -= HP;
        Instantiate(explostionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            OnTriggerBulletEnter(other.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            OnTriggerPlayerEnter(other.gameObject);
        }
    }
    IEnumerator getHit()
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
    public void Move()
    {
        int direc;
        if (fly_up)
        {
            direc = -1;
        }
        else
        {
            direc = 1;
        }

        if (typePath == TypePath.curve_up)
        {
            transform.localScale = new Vector3(direc * saveScale.x, saveScale.y, 0);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.eulerAngles.z - speedTurn));
            transform.position += direc * transform.right * offset;
        }
        if (typePath == TypePath.curve_down)
        {
            transform.localScale = new Vector3(-direc * saveScale.x, saveScale.y, 0);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.eulerAngles.z + speedTurn));
            transform.position -= direc * transform.right * offset;
        }
        if (typePath == TypePath.line)
        {
            if (anchor == Anchor_Plane.top)
            {
                //transform.localScale = new Vector3(direc*saveScale.x,saveScale.y,0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -90));
                transform.position += transform.right * offset;
            }
            else if (anchor == Anchor_Plane.right)
            {
                //transform.localScale = new Vector3(saveScale.x, saveScale.y, 0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                transform.position += transform.right * offset;
            }
            else if (anchor == Anchor_Plane.left)
            {
                // transform.localScale = new Vector3(saveScale.x, saveScale.y, 0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                transform.position += transform.right * offset;
            }
            else if (anchor == Anchor_Plane.top_left)
            {
                //transform.localScale = new Vector3(direc * saveScale.x, saveScale.y, 0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -60));
                transform.position += transform.right * offset;
            }
            else if (anchor == Anchor_Plane.top_right)
            {
                //transform.localScale = new Vector3(direc * saveScale.x,saveScale.y,0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -120));
                transform.position += transform.right * offset;
            }
        }
    }
}
