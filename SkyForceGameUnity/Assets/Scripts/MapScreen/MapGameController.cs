using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MapGameController : MonoBehaviour
{
    [SerializeField] SaveGame saveGame;
    public VerticalMainMenuXbox verticalMainMenuXbox;
    public int currentLevel;
    private int selectLevel;
    public int numberOfLevel;
    public GameObject[] ButtonLevels;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale =1;
       currentLevel = saveGame.currentLevelComplete;
    
        verticalMainMenuXbox.selectPanel();
        gameObject.GetComponent<VerticalMainMenuXbox>().selectPanel();
        SetupLevelSpriteScreen();
        verticalMainMenuXbox.select = currentLevel-1;
         
    }

    // Update is called once per frame
    void Update()
    {
        
        selectLevel = verticalMainMenuXbox.select;
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
        ButtonLevels[selectLevel].gameObject.GetComponent<Animator>().SetBool("Select",true);
    }
    public void PlayLevel()
    {
        int n = selectLevel;
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

