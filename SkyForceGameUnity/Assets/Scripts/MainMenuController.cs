using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
     public  int currentLevel;
     public int numberOfLevel;
    public GameObject[] ButtonLevels;
  
    [SerializeField] GameObject PanelSetting;
    [SerializeField] GameObject PanelUpgrade;

    [SerializeField] GameObject PanelMapGame;
    // Start is called before the first frame update
    void Start()
    {
       
          PanelSetting.SetActive(false);
          SetupLevelSpriteScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        OpenMapGame();
       
    }
    
    public void OpenSettingGame()
    {
        PanelSetting.SetActive(true);
    }
    public void CloseSettingGame()
    {
        PanelSetting.SetActive(false);
    }
     public void OpenUpgradeGame()
    {
        PanelUpgrade.SetActive(true);
    }
    public void CloseUpgradeGame()
    {
        PanelUpgrade.SetActive(false);
    }
    public void OpenMapGame()
    {
        PanelMapGame.SetActive(true);
    }
    public void HideMapGame()
    {
        PanelMapGame.SetActive(false);
    }
    public void OpenShopGame()
    {

    }
    public void RunLevel1()
    {
        
        GameObject star = ButtonLevels[0].transform.GetChild(0).gameObject;
        star.GetComponent<StarLevelController>().SetStar(1);
        Debug.Log("Run Level 1");

    }
    public void SetupLevelSpriteScreen()
    {
      
             for(int i = 0;i<currentLevel-1;i++)
            {   
              ButtonLevels[i].gameObject.GetComponent<LevelController>().SetStatusComplete();
             

            }
            for(int i = numberOfLevel-1;i>currentLevel-1;i--)
            {
                 ButtonLevels[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            ButtonLevels[currentLevel -1].gameObject.GetComponent<LevelController>().SetStatusAttackGame();
    }

    public void StartLevel()
    {
         SceneManager.LoadScene("PlayScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
