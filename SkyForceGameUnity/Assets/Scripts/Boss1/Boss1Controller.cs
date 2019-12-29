using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : MonoBehaviour
{
    public bool CanMove;
    public GameObject turret1;
    public GameObject turret2;
    public GameObject turret3;

    public GameObject turret4;
    public GameObject MainTurret;
    public float hp;
    private bool checkTurretStillCanWork;
    private bool checkAlive;// if check alive == false win game;
    // Start is called before the first frame update
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

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (checkTurretStillCanWork == true)
        {
            if (other.gameObject.tag == "bullet")
            {
                int damageOfBullet=  FindObjectOfType<BulletController>().Power;
                hp= hp - damageOfBullet;
                if(hp <= 0)
                {
                    FindObjectOfType<GameManager>().gameWin();
                    Destroy(gameObject);
                }
            }
        }

    }


}
