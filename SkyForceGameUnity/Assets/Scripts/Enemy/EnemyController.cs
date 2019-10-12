using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int numberEnemy = 1;
    public float gravity = 20.0f;
   // public float speed = 6.0f;
    public float heal = 100f;
    private Rigidbody2D rigidbody2d;
    public Anchor_Plane anchor;
    public TypePath  typePath;
    public bool fly_up;
    public float speedTurn;
    private float offset;
    public float speedMove;
    private GameManager _gameManager;
    private Vector2 saveScale;
    // Start is called before the first frame update
    void Start()
    {
        offset = Time.deltaTime * speedMove;
        rigidbody2d = GetComponent<Rigidbody2D>();
        saveScale = transform.localScale;
        _gameManager = FindObjectOfType<GameManager>();
        

    }

    // Update is called once per frame
    void Update()
    {
       //transform.Translate(0,1*Time.deltaTime,0);
    }
    private void FixedUpdate() {
        offset = Time.deltaTime*speedMove;
        Move();
    }
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Dan");
        if(other.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
    public void Move()
    {
        int direc;
        if(fly_up)
        {
            direc = -1;
        }
        else
        {
            direc = 1;
        }

        if(typePath == TypePath.curve_up)
        {
            transform.localScale = new Vector3(direc * saveScale.x,saveScale.y,0);
            transform.localRotation = Quaternion.Euler(new Vector3(0,0,transform.eulerAngles.z-speedTurn));
            transform.position+=direc * transform.right * offset;
        }
        if (typePath == TypePath.curve_down)
        {
            transform.localScale = new Vector3(-direc * saveScale.x, saveScale.y, 0);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.eulerAngles.z + speedTurn));
            transform.position -= direc * transform.right * offset;
        }
        if(typePath == TypePath.line)
        {
            if(anchor == Anchor_Plane.top)
            {
                transform.localScale = new Vector3(direc*saveScale.x,saveScale.y,0);
                transform.localRotation = Quaternion.Euler(new Vector3(0,0,-90));
                transform.position += transform.right * offset;
            }
            else if(anchor == Anchor_Plane.right)
            {
                transform.localScale = new Vector3(saveScale.x, saveScale.y, 0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                transform.position += transform.right * offset;
            }
            else if(anchor == Anchor_Plane.left)
            {
                transform.localScale = new Vector3(saveScale.x, saveScale.y, 0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                transform.position += transform.right * offset;
            }
            else if(anchor == Anchor_Plane.top_left)
            {
                transform.localScale = new Vector3(direc * saveScale.x, saveScale.y, 0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -60));
                transform.position += transform.right * offset;
            }
        }
    }
}
