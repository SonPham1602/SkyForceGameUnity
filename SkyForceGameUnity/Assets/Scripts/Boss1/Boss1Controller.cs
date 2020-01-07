using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1Controller : MonoBehaviour
{
    private int Direction;
    public bool CanMove;
    public GameObject turret1;
    public GameObject turret2;
    public GameObject turret3;

    public GameObject turret4;
    public GameObject MainTurret;
    public Image healthBarBoss;
    public GameObject healthBar;
    public float hp;
    private float HpOfBoss;
    private bool checkTurretStillCanWork;
    private bool checkAlive;// if check alive == false win game;
    // Start is called before the first frame update
    public bool canShootTurret;
    float fEnemyX;
    void Start()
    {
        HpOfBoss = hp;
        Direction = 1;
        fEnemyX = gameObject.transform.position.x;
        checkTurretStillCanWork = true;
        if (CanMove == false)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckTurretAlive();
        if (canShootTurret == true)
        {
            TurnOnAllTurret();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else 
        {
            gameObject.GetComponent<BoxCollider2D>().enabled  =true;
        }
        healthBarBoss.fillAmount = hp / HpOfBoss;
        MovingRandom();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (checkTurretStillCanWork == true)
        {
            if (other.gameObject.tag == "bullet")
            {
                int damageOfBullet = FindObjectOfType<BulletController>().Power;
                hp = hp - damageOfBullet;
                if (hp <= 0)
                {
                    HideHealthBar();
                    FindObjectOfType<GameManager>().gameWin();
                    Destroy(gameObject);
                }
            }
            else if (other.gameObject.tag == "enableEnemy")
            {
                canShootTurret = true;
            }
        }

    }
    public void ShowHealthBar()
    {
        healthBar.gameObject.GetComponent<Animator>().SetBool("Show", true);
        healthBar.gameObject.GetComponent<Animator>().SetBool("Hide", false);

    }
    public void HideHealthBar()
    {
        healthBar.gameObject.GetComponent<Animator>().SetBool("Hide", true);
        healthBar.gameObject.GetComponent<Animator>().SetBool("Show", false);
    }
    public void TurnOnAllTurret()
    {
        turret1.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
        turret2.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
        turret3.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
        turret4.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
        MainTurret.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
    }
    void CheckTurretAlive()
    {
        
        if(turret1.GetComponent<TurretEnemyController>().isBroken == true 
        && turret2.GetComponent<TurretEnemyController>().isBroken == true 
        && turret3.GetComponent<TurretEnemyController>().isBroken == true 
        && turret4.GetComponent<TurretEnemyController>().isBroken == true)
        {
            canShootTurret = false;
        }
    }
    void MovingRandom()
    {

        switch (Direction)
        {
            case -1:
                // Moving Left
                if (fEnemyX > -9)
                {
                    fEnemyX -= 1.0f * Time.deltaTime;
                }
                else
                {
                    // Hit left boundary, change direction
                    Direction = 1;
                }
                break;

            case 1:
                // Moving Right
                if (fEnemyX < 9)
                {
                    fEnemyX += 1.0f * Time.deltaTime;
                }
                else
                {
                    // Hit right boundary, change direction
                    Direction = -1;
                }
                break;
        }

        gameObject.transform.position = new Vector3(fEnemyX, gameObject.transform.position.y, 0.0f);

    }


}
