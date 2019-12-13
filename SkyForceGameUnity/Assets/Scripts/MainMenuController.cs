using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
     public  int currentLevel;
     public int numberOfLevel;
    public GameObject[] ButtonLevels;
    GameState gameState;
    [SerializeField] GameObject PanelSetting;
    [SerializeField] GameObject PanelUpgrade;

    [SerializeField] GameObject PanelMapGame;
    [SerializeField] GameObject PanelButtons;
    [SerializeField] GameObject ImagePressAnyKey;
    [SerializeField] GameObject PanelSoundSetting;
    [SerializeField] GameObject PanelControllerSetting;
    [SerializeField] GameObject PanelScreenSetting;
    [SerializeField] GameObject PanelHelpSetting;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.None;
        ImagePressAnyKey.SetActive(true);
        PanelButtons.SetActive(false);
        PanelSetting.SetActive(false);
        SetupLevelSpriteScreen();
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
            gameState = GameState.Play;
            ImagePressAnyKey.SetActive(false);
            PanelButtons.SetActive(true);

         
          }
       
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
    public void ShowSoundSettingInSetting()
    {
        HideAllPanelSettingInSetting();
        PanelSoundSetting.SetActive(true);
    }
    public void ShowControllerSettingInSetting()
    {
        HideAllPanelSettingInSetting();
        PanelControllerSetting.SetActive(true);
    }
    public void ShowScreenSettingInSetting()
    {
        HideAllPanelSettingInSetting();
        PanelScreenSetting.SetActive(true);
    }
    public void ShowHelpInSetting()
    {
        HideAllPanelSettingInSetting();
        PanelHelpSetting.SetActive(true);
    }
    public void HideAllPanelSettingInSetting()
    {
        PanelHelpSetting.SetActive(false);
        PanelScreenSetting.SetActive(false);
        PanelSoundSetting.SetActive(false);
        PanelControllerSetting.SetActive(false);
    }
   

}
