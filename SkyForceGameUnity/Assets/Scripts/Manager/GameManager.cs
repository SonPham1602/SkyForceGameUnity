using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    None,
    Play,
    Pause,
    EndGame,
    GameOver,
}
public class GameManager : MonoBehaviour
{

    public GameObject[] list_plane;//Danh sach may bay cua nguoi choi
    public Transform pointGen;
    public int point;
    public GameState gameState = GameState.None;
    public TypeControllerGame typeControllerGame;
    // Start is called before the first frame updat

    public GameObject titleStartGame;
    public GameObject cloudStartGame;
    public Transform targetmove;
    [SerializeField] GameObject listEnemy;
    [SerializeField] GameObject missionController;
    [SerializeField] GameObject panelGameOver;
    [SerializeField] GameObject panelGameComplete;
    void Start()
    {
        titleStartGame.GetComponent<Animator>().SetBool("Show", true);
        titleStartGame.GetComponent<Animator>().SetBool("Hide", false);
        typeControllerGame = GameSetting.typeControllerGame;
        SetupMissionGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (typeControllerGame == TypeControllerGame.GamePad)
        {
            if (Input.GetKeyDown("joystick button 0") && gameState == GameState.None)
            {
                if (Input.GetMouseButtonDown(0)
                  || Input.GetMouseButtonDown(1)
                  || Input.GetMouseButtonDown(2))
                    return; //Do Nothing
                Debug.Log("Press Any Key");
                // titleStartGame.SetActive(false);
                titleStartGame.GetComponent<Animator>().SetBool("Show", false);
                titleStartGame.GetComponent<Animator>().SetBool("Hide", true);

                // Destroy(titleStartGame);
                FindObjectOfType<GameManager>().gameState = GameState.Play;

            }
            if (gameState == GameState.Play)
            {
                listEnemy.GetComponent<ControllerListEnemy>().StartOrCountinueMovingEnemy();
                cloudStartGame.gameObject.transform.position = Vector2.MoveTowards(cloudStartGame.gameObject.transform.position, targetmove.position, 8 * Time.deltaTime);
            }

        }
        else if(typeControllerGame == TypeControllerGame.MouseAndKeyboard)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                titleStartGame.GetComponent<Animator>().SetBool("Show",false);
                titleStartGame.GetComponent<Animator>().SetBool("Hide",true);
                FindObjectOfType<GameManager>().gameState = GameState.Play;
            }
            if(gameState == GameState.Play)
            {
                listEnemy.GetComponent<ControllerListEnemy>().StartOrCountinueMovingEnemy();
                cloudStartGame.gameObject.transform.position = Vector2.MoveTowards(cloudStartGame.gameObject.transform.position, targetmove.position, 8 * Time.deltaTime);
            }
        }

    }

    public void gameWin()
    {
        gameState = GameState.EndGame;
        panelGameComplete.SetActive(true);
        panelGameComplete.GetComponent<CompleteGamePanel>().SetupPanelCompleteGame(GameSetting.ScoreGame,GameSetting.StarGame);

        
    }

    public void gameOver()
    {
        gameState = GameState.GameOver;
        panelGameOver.SetActive(true);
        Time.timeScale = 0f;
    }
    void SetupMissionGame()
    {
        
        missionController.GetComponent<MissionController>().UnsetAllToggel();
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void ResetLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    

}
