using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject PanelSetting;
    [SerializeField] GameObject PanelUpgrade;

    [SerializeField] GameObject PanelMapGame;
    // Start is called before the first frame update
    void Start()
    {
          PanelSetting.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
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

    }
    public void OpenShopGame()
    {

    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
