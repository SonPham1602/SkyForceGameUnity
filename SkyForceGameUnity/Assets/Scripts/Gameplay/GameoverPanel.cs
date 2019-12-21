using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameSetting.typeControllerGame== TypeControllerGame.GamePad)
        {
            if(Input.GetKeyDown("joystick button 0"))
            {
                GoToMapScene();
            }
            else if(Input.GetKeyDown("joystick button 3"))
            {
                ResetGame();
            }
        }
    }
    void GoToMapScene()
    {
        
    }
    void ResetGame()
    {
        SceneManager.LoadScene(1);
    }
}
