using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapGameController : MonoBehaviour
{
    public int currentLevel;
    public int numberOfLevel;
    public GameObject[] ButtonLevels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToPlayGame(int n)
    {
        SceneManager.LoadScene(n);
    }
}
