using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Anchor_Plane {top,top_left,top_right,right,left, bottom_left,bottm_right};
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
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
