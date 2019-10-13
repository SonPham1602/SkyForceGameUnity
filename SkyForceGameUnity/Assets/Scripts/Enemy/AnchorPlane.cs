using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Anchor_Plane {top,top_left,top_right,right,left, bottom_left,bottom_right };
public enum TypePath {none,line,curve_up,curve_down}
public class AnchorPlane : MonoBehaviour
{
    private Vector2 positionCam;
    private Vector2 size;//size of screen
    private Vector2 top = new Vector2(0, -3);
    private Vector2 top_left = new Vector2(-5, -3);
    private Vector2 top_right = new Vector2(5, -3);
    private Vector2 left = new Vector2(-5, -10);
    private Vector2 right = new Vector2(5, -10);
    private Vector2 botton_left = new Vector2(-5, -17);
    private Vector2 botton_right = new Vector2(5, -17);
    public Anchor_Plane anchor_start;
    public TypePath type_Path;
    public float speedMove;
    public float speedTurn;
    public bool fly_up;
    public float timeDelay = 0.5f;
    private void Awake() {
        positionCam = GameSetting.positionCam;
        size = new Vector2(Mathf.Abs(GameSetting.sizeCam.x/2)+2,Mathf.Abs(GameSetting.sizeCam.y/2)+2);
        top = new Vector2(0, positionCam.y + size.y);
        top_left = new Vector2(positionCam.x - size.x, positionCam.y + size.y);
        top_right = new Vector2(positionCam.x + size.x, positionCam.y + size.y);
        left = new Vector2(positionCam.x - size.x, positionCam.y);
        right = new Vector2(positionCam.x + size.x, positionCam.y);
        botton_left = new Vector2(-5, positionCam.y - size.y);
        botton_right = new Vector2(5, positionCam.y - size.y);
        transform.position = resultPosition(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector2 resultPosition()
    {
        switch (anchor_start)
        {
            case Anchor_Plane.top:
                StartCoroutine("settingPlane");
                return top;
            case Anchor_Plane.top_left:
                StartCoroutine("settingPlane");
                return top_left;
            case Anchor_Plane.top_right:
                StartCoroutine("settingPlane");
                return top_right;
            case Anchor_Plane.left:
                StartCoroutine("settingPlane");
                return left;
            case Anchor_Plane.right:
                StartCoroutine("settingPlane");
                return right;
            case Anchor_Plane.bottom_left:
                StartCoroutine("settingPlane");
                return botton_left;
            case Anchor_Plane.bottom_right:
                StartCoroutine("settingPlane");
                return botton_right;
        }

        return Vector2.zero;
    }


    IEnumerator settingPlane()
    {
        //Set up plane
        for(int i = transform.childCount-1;i>=0;i--)
        {
            EnemyController enemy = transform.GetChild(i).GetComponent<EnemyController>();
            if(enemy!=null)
            {
                enemy.anchor = anchor_start;
                enemy.typePath = type_Path;
                enemy.speedMove = speedMove;
                enemy.speedTurn = speedTurn;
                enemy.fly_up = fly_up;
            }
        }

        //Start create array of enemy
        
        for(int i = transform.childCount - 1;i >=0;i--)
        {
            EnemyController enemy = transform.GetChild(i).GetComponent<EnemyController>();
            if(enemy!=null)
            {
                enemy.canMove = true;
                yield return new WaitForSeconds(timeDelay);
            }
        }
    }
}
