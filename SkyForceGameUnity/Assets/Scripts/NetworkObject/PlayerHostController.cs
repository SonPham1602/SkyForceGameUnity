using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHostController : PlayerController
{
    public Player user;
    public static PlayerHostController Instance;
    private Vector3 oldPosition;

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

        if (transform.position != oldPosition && OnlineGameController.Instance.startGame)
        {
            SocketClient.Instance.AddMessage(MessageWriter.getMessageChangePosition(0, transform.position));
            oldPosition = transform.position;
        }
    }
    
    protected void CreateOneBullet(Vector3 pos, GameObject bullet, float speed)
    {
        SocketClient.Instance.AddMessage(MessageWriter.getShotBulletMessage(1));
        base.CreateOneBullet(pos, bullet, speed);
    }
}
