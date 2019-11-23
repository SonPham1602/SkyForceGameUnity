using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState 
{
    None,
    Play,
    Pause,
    EndGame,
}
public class GameManager : MonoBehaviour
{

    public GameObject[] list_plane;
    public Transform pointGen;
    public int point;
    public GameState gameState = GameState.None;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameWin()
    {
        gameState = GameState.EndGame;
    }

    public void gameOver()
    {
        Time.timeScale = 0f;
    }

}
