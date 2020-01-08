﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeControllerGame
{
    MouseAndKeyboard,
    GamePad

}
public enum LevelOfBulletPlayer
{
    Level1,
    Level2,
    Level3,
    Level4,
    Level5
}
public enum LevelOfHealthPlayer
{
    Level1,
    Level2,
    Level3,
    Level4,
    Level5
}
public enum LevelOfRocketPlayer
{
    None,
    Level1,
    Level2,
    Level3,
    Level4,
    Level5
}
public enum LevelOfSpeedPlayer
{

    Level1,
    Level2,
    Level3,
    Level4,
    Level5
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] protected LevelOfBulletPlayer levelOfBulletPlayer;
    [SerializeField] protected LevelOfHealthPlayer levelOfHealthPlayer;
    [SerializeField] protected LevelOfRocketPlayer levelOfRocketPlayer;
    [SerializeField] protected GameObject HomingMissile;

    public AudioClip shootBulletSound;
    public AudioSource audioSource;
    public int damageOfBullet;
    public float timeSpeedShot;
    public GameObject target;
    public GameObject startShot;
    public GameObject bullet;
    public int numberBullet = 1;
    public float hp;// hp cua may bay
    public float speedShip = 100f;

    protected float radius;
    protected float lastTimeFire = 0;
    protected float timeToShot;

    public GameObject[] planeChild;
    protected Rigidbody2D rb;
    protected Vector2 direction;
    protected bool isMove;
    public TypeControllerGame typeControllerGame;
    [SerializeField] protected GameObject hitLayer;


    public bool canMove;

    public float HP
    {

        get => hp;
        set
        {
            hp = value;
            if (hp <= 30 && hp > 0)
            {

                hitLayer.GetComponent<Animator>().SetTrigger("ShowLowHealth");

            }
            else if (hp <= 0)
            {
                FindObjectOfType<GameManager>().gameOver();
            }
        }
    }

    struct BulletPos
    {
        public Vector2 pos1;
        public Vector2 pos2;
    };

    struct ValueEquation
    {
        public float x1;
        public float x2;
    };

    // Start is called before the first frame update
    protected void Start()
    {
        timeToShot = 5f;
        radius = Vector3.Magnitude(target.transform.position - gameObject.transform.position);
        this.HP = 100;
        rb = GetComponent<Rigidbody2D>();
    }
    void OnMouseOver()
    {
        isMove = false;
        //Debug.Log("Move false");
    }
    /// <summary>
    /// Called when the mouse is not any longer over the GUIElement or Collider.
    /// </summary>
    void OnMouseExit()
    {
        isMove = true;
        //Debug.Log("Move true");
    }

    // Update is called once per frame
    protected void Update()
    {
        typeControllerGame = GameSetting.typeControllerGame;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (typeControllerGame == TypeControllerGame.MouseAndKeyboard && canMove == true)
        {
            if (Mathf.Abs(mousePosition.x) <= 28 && Mathf.Abs(mousePosition.y) <= 16)
            {

                direction = (mousePosition - new Vector2(transform.position.x, transform.position.y)).normalized;
                // Debug.Log(direction.x+ "   " + direction.y);
                //Debug.Log(mousePosition.x + "   " + mousePosition.y + "   " + transform.position.x + "  " + transform.position.y);
                if (isMove != false)
                {
                    rb.velocity = new Vector2(direction.x * speedShip, direction.y * speedShip);
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    gameObject.transform.Translate((mousePosition - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)) * Time.deltaTime * speedShip);
                }
            }
            else
            {

                if (((mousePosition.x) > 28))
                {
                    mousePosition.x = 26;
                    isMove = false;
                }
                else if (mousePosition.x < -28)
                {
                    mousePosition.x = -26;
                    isMove = false;
                }
                if (((mousePosition.y) > 16))
                {
                    mousePosition.y = 14;
                    isMove = false;
                }
                else if (mousePosition.y < -16)
                {
                    mousePosition.y = -14;
                    isMove = false;
                }
                direction = (mousePosition - new Vector2(transform.position.x, transform.position.y)).normalized;
                if (isMove != false)
                {
                    rb.velocity = new Vector2(direction.x * speedShip, direction.y * speedShip);
                }
                else
                {
                    if (Mathf.Abs(mousePosition.x) > 24 || Mathf.Abs(mousePosition.y) > 12)
                    {
                        rb.velocity = Vector2.zero;
                        gameObject.transform.Translate((mousePosition - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)) * Time.deltaTime * speedShip);
                    }
                    else
                    {
                        rb.velocity = new Vector2(direction.x * speedShip, direction.y * speedShip);
                    }

                }
            }
            // Ship will shot when press enter
            if (Time.time - lastTimeFire >= timeSpeedShot && GameObject.FindObjectOfType<GameManager>().gameState == GameState.Play)
            {
                lastTimeFire = Time.time;
                //CreateBullet(bullet);
                CreateOneBullet(target.transform.position, bullet, 15);
                audioSource.clip = shootBulletSound;
                audioSource.Play();
            }
            if (GameObject.FindObjectOfType<GameManager>().gameState == GameState.Play)
            {
                ControllerRocketPlayer();
            }


            //rb.velocity = Vector2.zero;
        }
        else if (typeControllerGame == TypeControllerGame.GamePad && canMove == true)
        {
            float translationY = Input.GetAxis("Vertical") * speedShip * Time.deltaTime;
            float translationX = Input.GetAxis("Horizontal") * speedShip * Time.deltaTime;

            //float MoveX = Mathf.Clamp(translationX+transform.position,GameSetting.sizeCam.x*-1,GameSetting.sizeCam.x);
            if (Mathf.Abs(transform.position.x + translationX) <= GameSetting.screenBound.x && Mathf.Abs(transform.position.y + translationY) <= GameSetting.screenBound.y)
            {
                transform.Translate(translationX, translationY, 0);
            }

            //transform.position = viewPos;



            if (Time.time - lastTimeFire >= timeSpeedShot && GameObject.FindObjectOfType<GameManager>().gameState == GameState.Play)
            {
                lastTimeFire = Time.time;
                CreateBullet(bullet);
                audioSource.clip = shootBulletSound;
                audioSource.Play();
            }
            if (GameObject.FindObjectOfType<GameManager>().gameState == GameState.Play)
            {
                ControllerRocketPlayer();
            }
        }


        // check low health of player



    }

    //Create bullet
    protected void CreateBullet(GameObject bullet)
    {
        float Goc = 0.1f;
        BulletPos bulletPos;
        int dem = numberBullet;

        if (numberBullet % 2 == 1)
        {
            CreateOneBullet(target.transform.position, bullet, 10);
            Goc = 0.1f;
            dem--;
        }
        else
        {
            Goc = 0.06f;
        }

        for (int i = 1; i <= dem / 2; i++)
        {
            setBulletPos(out bulletPos, Goc * i);
            CreateOneBullet(bulletPos.pos1, bullet, 10);
            CreateOneBullet(bulletPos.pos2, bullet, 10);
        }
    }

    protected void CreateOneBullet(Vector3 pos, GameObject bullet, float speed)
    {
        GameObject b = Instantiate(bullet, startShot.transform.position, Quaternion.identity);
        b.GetComponent<BulletController>().targetPosition = pos;
        b.GetComponent<BulletController>().moveSpeed = speed;
        b.GetComponent<BulletController>().Power = damageOfBullet;
    }

    private void setBulletPos(out BulletPos pos, float goc)
    {
        Vector3 shipPos = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y, 0);
        //hệ số phương trình khoảng cách |ax + by +c|=d
        Vector4 heSo = new Vector4(shipPos.y - targetPos.y, targetPos.x - shipPos.x,
                                    -1 * ((shipPos.y - targetPos.y) * shipPos.x + (targetPos.x - shipPos.x) * shipPos.y),
                                    radius * Mathf.Sin(goc) * Mathf.Sqrt(Mathf.Pow(shipPos.y - targetPos.y, 2.0f) + Mathf.Pow(targetPos.x - shipPos.x, 2.0f)));
        Vector3 heSoPtBac2 = new Vector3();
        Vector3 temp1, temp2;
        //giải tìm tọa độ
        float d = heSo.w;
        ValueEquation nghiem;
        heSoPtBac2.x = Mathf.Pow(heSo.y / heSo.x, 2) + 1;
        heSoPtBac2.y = 2 * ((-1 * heSo.y / heSo.x) * ((d - heSo.z) / heSo.x - shipPos.x) - shipPos.y);
        heSoPtBac2.z = Mathf.Pow((d - heSo.z) / heSo.x - shipPos.x, 2.0f) + Mathf.Pow(shipPos.y, 2.0f) - Mathf.Pow(radius, 2.0f);
        giaiPt(heSoPtBac2, out nghiem);
        temp1 = new Vector3((d - heSo.z - heSo.y * nghiem.x1) / heSo.x, nghiem.x1, 0);
        temp2 = new Vector3((d - heSo.z - heSo.y * nghiem.x2) / heSo.x, nghiem.x2, 0);
        if (Vector3.Magnitude(temp1 - targetPos) < Vector3.Magnitude(temp2 - targetPos))
        {
            pos.pos1 = temp1;
        }
        else
        {
            pos.pos1 = temp2;
        }

        d = -1 * heSo.w;
        heSoPtBac2.x = Mathf.Pow(heSo.y / heSo.x, 2) + 1;
        heSoPtBac2.y = 2 * ((-1 * heSo.y / heSo.x) * ((d - heSo.z) / heSo.x - shipPos.x) - shipPos.y);
        heSoPtBac2.z = Mathf.Pow((d - heSo.z) / heSo.x - shipPos.x, 2.0f) + Mathf.Pow(shipPos.y, 2.0f) - Mathf.Pow(radius, 2.0f);
        giaiPt(heSoPtBac2, out nghiem);
        temp1 = new Vector3((d - heSo.z - heSo.y * nghiem.x1) / heSo.x, nghiem.x1, 0);
        temp2 = new Vector3((d - heSo.z - heSo.y * nghiem.x2) / heSo.x, nghiem.x2, 0);
        if (Vector3.Magnitude(temp1 - targetPos) < Vector3.Magnitude(temp2 - targetPos))
        {
            pos.pos2 = temp1;
        }
        else
        {
            pos.pos2 = temp2;
        }
    }

    private void giaiPt(Vector3 heSoPtBac2, out ValueEquation nghiem)
    {
        nghiem.x1 = 0;
        nghiem.x2 = 0;
        float delta = Mathf.Pow(heSoPtBac2.y, 2.0f) - 4 * heSoPtBac2.x * heSoPtBac2.z;
        if (delta == 0)
        {
            nghiem.x1 = nghiem.x2 = -heSoPtBac2.y / (2 * heSoPtBac2.x);
        }
        else if (delta > 0)
        {
            nghiem.x1 = (-heSoPtBac2.y + Mathf.Sqrt(delta)) / (2 * heSoPtBac2.x);
            nghiem.x2 = (-heSoPtBac2.y - Mathf.Sqrt(delta)) / (2 * heSoPtBac2.x);
        }
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bulletEnemy")
        {
            Destroy(other.gameObject);
            hitLayer.GetComponent<Animator>().SetTrigger("ShowOneHit");
            // Mission 1 fail
            GameObject.FindObjectOfType<GameManager>().CheckCompleteMisson1 = false;
        }
        else if (other.gameObject.tag == "enemy")
        {
            hitLayer.GetComponent<Animator>().SetTrigger("ShowOneHit");
            // Mission 1 fail
            GameObject.FindObjectOfType<GameManager>().CheckCompleteMisson1 = false;
        }
        else if (other.gameObject.tag == "misileEnemy")
        {
            hitLayer.GetComponent<Animator>().SetTrigger("ShowOneHit");
            // Mission 1 fail
            GameObject.FindObjectOfType<GameManager>().CheckCompleteMisson1 = false;
        }

    }
    protected void ControllerRocketPlayer()
    {
        if (levelOfRocketPlayer == LevelOfRocketPlayer.Level1)
        {

            if (timeToShot <= 0)
            {
                Instantiate(HomingMissile, transform.position, Quaternion.Euler(0f,0f,-130f));
                timeToShot = 5f;

            }
            else
            {
                timeToShot -= Time.deltaTime;
            }
        }
    }

}
