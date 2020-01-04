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
        if (GameSetting.typeControllerGame == TypeControllerGame.MouseAndKeyboard)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameIsPaused = !GameIsPaused;
                if (GameIsPaused == true)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }

            }
        }
        else if (GameSetting.typeControllerGame == TypeControllerGame.GamePad)
        {
            // System.Array values = System.Enum.GetValues(typeof(KeyCode));
            // foreach (KeyCode code in values)
            // {
            //     if (Input.GetKeyDown(code)) { print(System.Enum.GetName(typeof(KeyCode), code)); }
            // }
            if (Input.GetKeyDown("joystick button 6"))
            {
                GameIsPaused = !GameIsPaused;
                if (GameIsPaused == true)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }
            }
        }

    }
    public void OpenAndClosPausePanel()
    {
        GameIsPaused = !GameIsPaused;
        if (GameIsPaused == true)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
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
