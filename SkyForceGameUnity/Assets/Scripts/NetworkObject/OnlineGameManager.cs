using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineGameManager : MonoBehaviour
{
    public GameObject[] list_plane;//Danh sach may bay cua nguoi choi
    public Transform pointGen;
    public int point;
    public GameState gameState = GameState.None;
    public TypeControllerGame typeControllerGame;
    // Start is called before the first frame updat

    public GameObject cloudStartGame;
    public Transform targetmove;
    [SerializeField] GameObject listEnemy;
    [SerializeField] GameObject panelGameOver;
    [SerializeField] GameObject panelGameComplete;
    [SerializeField] GameObject healthBar;

    public static OnlineGameManager Instance { get; set; }

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Play)
        {
            listEnemy.GetComponent<ControllerListEnemy>().StartOrCountinueMovingEnemy();
            healthBar.GetComponent<Animator>().SetBool("Show", true);
            cloudStartGame.gameObject.transform.position = Vector2.MoveTowards(cloudStartGame.gameObject.transform.position, targetmove.position, 8 * Time.deltaTime);
        }
    }

    public void gameWin()
    {
        gameState = GameState.EndGame;
        panelGameComplete.SetActive(true);
        panelGameComplete.GetComponent<CompleteGamePanel>().SetupPanelCompleteGame(GameSetting.ScoreGame, GameSetting.StarGame, GameSetting.numberMissionComplete);
        SocketClient socket = GameObject.FindObjectOfType<SocketClient>();
        if (socket != null)
        {
            socket.AddMessage(MessageWriter.getWinGameMessage());
        }
    }

    public void gameOver()
    {
        gameState = GameState.GameOver;
        panelGameOver.SetActive(true);
        Time.timeScale = 0f;
    }
}
