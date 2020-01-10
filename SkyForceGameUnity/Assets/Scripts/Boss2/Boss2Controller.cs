using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2Controller : MonoBehaviour
{
    public float hp;
    private float HpOfBoss;
    private bool checkTurretStillCanWork;
    public GameObject turret1;
    public GameObject turret2;
    public GameObject turret3;

    public GameObject turret4;
    public GameObject MainTurret;
    public Image healthBarBoss;

    public bool CanMove;
    public bool canShootTurret;
    public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {
        HpOfBoss = hp;
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
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        healthBarBoss.fillAmount = hp / HpOfBoss;
    }
    void CheckTurretAlive()
    {

        if (turret1.GetComponent<TurretEnemyController>().isBroken == true
        && turret2.GetComponent<TurretEnemyController>().isBroken == true
        && turret3.GetComponent<TurretEnemyController>().isBroken == true
        && turret4.GetComponent<TurretEnemyController>().isBroken == true)
        {
            canShootTurret = false;
        }
    }
    public void TurnOnAllTurret()
    {
        turret1.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
        turret2.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
        turret3.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
        turret4.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
        MainTurret.gameObject.GetComponent<TurretEnemyController>().EnableTurret();
    }
    public void ShowHealthBar()
    {
        healthBar.gameObject.GetComponent<Animator>().SetBool("Show", true);
        healthBar.gameObject.GetComponent<Animator>().SetBool("Hide", false);

    }
}
