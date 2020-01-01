using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1Controller : MonoBehaviour
{
    public bool CanMove;
    public GameObject turret1;
    public GameObject turret2;
    public GameObject turret3;

    public GameObject turret4;
    public GameObject MainTurret;
    public Image healthBarBoss;
    public GameObject healthBar;
    public float hp;
    private bool checkTurretStillCanWork;
    private bool checkAlive;// if check alive == false win game;
    // Start is called before the first frame update
    public bool canShootTurret;
    void Start()
    {
        checkTurretStillCanWork = true;
        if (CanMove == false)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canShootTurret == true)
        {
            TurnOnAllTurret();
        }
        healthBarBoss.fillAmount = hp / 1000;
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
        //turret1.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
        //turret2.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
        //turret3.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
        //turret4.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
        MainTurret.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
    }


}
