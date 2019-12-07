using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControllerGamePlay : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] GameObject panelPauseGame;

    // Start is called before the first frame update
    void Start()
    {
           ResumeGame();
    }

  
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameIsPaused =! GameIsPaused;
            if(GameIsPaused == true)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
            
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        panelPauseGame.SetActive(true);
    }
    void ResumeGame()
    {
        Time.timeScale = 1f;
        panelPauseGame.SetActive(false);
    }
}
