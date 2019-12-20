using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSetting : MonoBehaviour
{
    public static int ScoreGame;
    public TextMeshProUGUI titleScoreGame;
    public static GameSetting instance;
    public static Vector2 sizeCam;
    public static Vector2 positionCam;
    public static int level;
    //Thong so may bay moi man choi
    public  int lifePlayer;
    public static float speed_plane;
    public static float armor_plane;
    public static float attack_plane;
    public static Vector2 screenBound;
    public static TypeControllerGame typeControllerGame;
    private bool StartGame;
    // Start is called before the first frame update
    private void Awake() {
        instance = this;
        sizeCam = new Vector2(2f*Camera.main.aspect*Camera.main.orthographicSize,2f * Camera.main.orthographicSize);
        positionCam = Camera.main.transform.position;
        typeControllerGame = TypeControllerGame.GamePad;
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
       

    }

    void Start()
    {
         ScoreGame = 0 ;
    }

    void setting_plane()
    {
        level = PlayerPrefs.GetInt(MenuScript.LEVEL_KEY);
    }
    string CreateStringCharZero(int n)
    {
        string result = "";
        for(int i = 0;i<n;i++)
        {
            result+="0";
        }
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        //Xu ly diem trong game
        titleScoreGame.text=CreateStringCharZero(12-ScoreGame.ToString().Length)+ScoreGame.ToString();
     
    }
}
