using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame updat

    public GameObject titleStartGame;
    public GameObject cloudStartGame;
    public Transform targetmove;
    [SerializeField] GameObject listEnemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.anyKeyDown && gameState==GameState.None)
          {
               if (Input.GetMouseButtonDown(0) 
                 || Input.GetMouseButtonDown(1)
                 || Input.GetMouseButtonDown(2))
                     return; //Do Nothing
            Debug.Log("Press Any Key");
            titleStartGame.SetActive(false);
           
           // Destroy(titleStartGame);
            FindObjectOfType<GameManager>().gameState = GameState.Play;

          }
          if(gameState == GameState.Play)
          {
                listEnemy.GetComponent<ControllerListEnemy>().StartOrCountinueMovingEnemy();
                cloudStartGame.gameObject.transform.position=Vector2.MoveTowards(  cloudStartGame.gameObject.transform.position,targetmove.position,8*Time.deltaTime);
          }
           
    }

    public void gameWin()
    {
        gameState = GameState.EndGame;
    }

    public void gameOver()
    {
        gameState = GameState.GameOver;
        Time.timeScale = 0f;
    }

}
