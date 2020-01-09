using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHostController : PlayerController
{
    public Player user;
    public static PlayerHostController Instance;
    private Vector3 oldPosition;

    public float HP
    {
        get => hp;
        set
        {
            hp = value;
            if (hp <= 30 && hp > 0)
            {
                if (hitLayer != null)
                {
                    hitLayer.GetComponent<Animator>().SetTrigger("ShowLowHealth");
                }
            }
            else if (hp <= 0)
            {
                FindObjectOfType<OnlineGameManager>().gameOver();
            }
        }
    }

    void Start()
    {
        Instance = this;
        base.Start();
        isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        typeControllerGame = GameSetting.typeControllerGame;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (typeControllerGame == TypeControllerGame.MouseAndKeyboard && canMove == true)
        {
            if (Mathf.Abs(mousePosition.x) <= 28 && Mathf.Abs(mousePosition.y) <= 16)
            {

                direction = (mousePosition - new Vector2(transform.position.x, transform.position.y)).normalized;
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
            if (Time.time - lastTimeFire >= timeSpeedShot && GameObject.FindObjectOfType<OnlineGameManager>().gameState == GameState.Play)
            {
                lastTimeFire = Time.time;
                CreateOneBullet(target.transform.position, bullet1, 15);
                audioSource.clip = shootBulletSound;
                audioSource.Play();
            }
            if (GameObject.FindObjectOfType<OnlineGameManager>().gameState == GameState.Play)
            {
                ControllerRocketPlayer();
            }
        }
        else if (typeControllerGame == TypeControllerGame.GamePad && canMove == true)
        {
            float translationY = Input.GetAxis("Vertical") * speedShip * Time.deltaTime;
            float translationX = Input.GetAxis("Horizontal") * speedShip * Time.deltaTime;

            if (Mathf.Abs(transform.position.x + translationX) <= GameSetting.screenBound.x && Mathf.Abs(transform.position.y + translationY) <= GameSetting.screenBound.y)
            {
                transform.Translate(translationX, translationY, 0);
            }

            if (Time.time - lastTimeFire >= timeSpeedShot && GameObject.FindObjectOfType<OnlineGameManager>().gameState == GameState.Play)
            {
                lastTimeFire = Time.time;
                CreateBullet(bullet1);
                audioSource.clip = shootBulletSound;
                audioSource.Play();
            }
            if (GameObject.FindObjectOfType<OnlineGameManager>().gameState == GameState.Play)
            {
                ControllerRocketPlayer();
            }
        }

        if (transform.position != oldPosition && OnlineGameController.Instance.startGame)
        {
            SocketClient.Instance.AddMessage(MessageWriter.getMessageChangePosition(0, transform.position));
            oldPosition = transform.position;
        }
    }
    
    protected void CreateOneBullet(Vector3 pos, GameObject bullet, float speed)
    {
        SocketClient.Instance.AddMessage(MessageWriter.getShotBulletMessage(1));
        base.CreateOneBullet(pos, bullet, speed,startShot);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bulletEnemy")
        {
            Destroy(other.gameObject);
            if (hitLayer != null)
                hitLayer.GetComponent<Animator>().SetTrigger("ShowOneHit");
        }
        else if (other.gameObject.tag == "enemy")
        {
            if (hitLayer != null)
                hitLayer.GetComponent<Animator>().SetTrigger("ShowOneHit");
        }
        else if (other.gameObject.tag == "misileEnemy")
        {
            if (hitLayer != null)
                hitLayer.GetComponent<Animator>().SetTrigger("ShowOneHit");
        }
    }
}
