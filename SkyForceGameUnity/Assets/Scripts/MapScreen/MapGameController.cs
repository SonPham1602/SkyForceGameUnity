using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MapGameController : MonoBehaviour
{
    [SerializeField] SaveGame saveGame;
    [SerializeField] VerticalMainMenuXbox verticalMainMenuXbox;
     int currentLevel;
    public int numberOfLevel;
    public GameObject[] ButtonLevels;

    // Start is called before the first frame update
    void Start()
    {
       currentLevel = saveGame.currentLevelComplete;
        verticalMainMenuXbox.selectPanel();
        SetupLevelSpriteScreen();
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = verticalMainMenuXbox.select;
        SetAnimationAttackLevel();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToPlayGame(int n)
    {
        SceneManager.LoadScene(n);
    }
     public void SetupLevelSpriteScreen()
    {
        for(int i=0;i<ButtonLevels.Length;i++)
        {
            ButtonLevels[i].gameObject.transform.GetChild(0).gameObject.GetComponent<StarLevelController>().SetStar(saveGame.levelInfomations[i].numberOfStar);
        }
        for (int i = 0; i < currentLevel - 1; i++)
        {
            ButtonLevels[i].gameObject.GetComponent<LevelController>().SetStatusComplete();


        }
        for (int i = numberOfLevel - 1; i > currentLevel - 1; i--)
        {
            ButtonLevels[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
            ButtonLevels[i].GetComponent<LevelController>().SetStatusLockGame();
        }
        ButtonLevels[currentLevel - 1].gameObject.GetComponent<LevelController>().SetStatusAttackGame();
         ButtonLevels[currentLevel-1].gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    private void SetAnimationAttackLevel()
    {
        for(int i=0;i<ButtonLevels.Length;i++)
        {
            ButtonLevels[i].gameObject.GetComponent<Animator>().SetBool("Select",false);
        }
        ButtonLevels[currentLevel].gameObject.GetComponent<Animator>().SetBool("Select",true);
    }
    public void PlayLevel()
    {
        int n = currentLevel;
        if(n==0)
        {
            PlayLevel1();
        }
        else if(n == 1)
        {
            PlayLevel2();
        }
        else if(n == 2)
        {
            PlayLevel3();
        }
        else if(n==3)
        {
             PlayLevel4();
        }
        else if(n==4)
        {
            PlayLevel5();
        }
        else if(n==5)
        {
             PlayLevel6();
        }
    }
    public void PlayLevel1()
    {
    
        SceneManager.LoadScene("Level1");
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
     public void PlayLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
     public void PlayLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
     public void PlayLevel5()
    {
        SceneManager.LoadScene("Level5");
    }
     public void PlayLevel6()
    {
        SceneManager.LoadScene("Level6");
    }

}

