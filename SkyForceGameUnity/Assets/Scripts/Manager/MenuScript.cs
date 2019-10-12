using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public static MenuScript instance;
    // Start is called before the first frame update

    public const string MENU_NAME = "MainMenu";
    public const string MAP_NAME = "Map";
    public const string LEVEL_KEY = "Level";
    public const string FIRST_GAME_CHECK = "firstGame";
    private void Awake() {
        instance = this;
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
