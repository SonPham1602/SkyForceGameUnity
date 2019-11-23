using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public static GameSetting instance;
    public static Vector2 sizeCam;
    public static Vector2 positionCam;
    public static int level;
    //Thong so may bay moi man choi
    public  int lifePlayer;
    public static float speed_plane;
    public static float armor_plane;
    public static float attack_plane;
    // Start is called before the first frame update
    private void Awake() {
        instance = this;
        sizeCam = new Vector2(2f*Camera.main.aspect*Camera.main.orthographicSize,2f * Camera.main.orthographicSize);
        positionCam = Camera.main.transform.position;
        setting_plane();
        FindObjectOfType<GameManager>().gameState = GameState.Play;

    }

    void Start()
    {
        
    }

    void setting_plane()
    {
        level = PlayerPrefs.GetInt(MenuScript.LEVEL_KEY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
