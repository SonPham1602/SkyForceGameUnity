using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public int currentLevel;
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
    [SerializeField] GameObject LogoGame;
    [SerializeField] GameObject MiddleButtons;
    [SerializeField] GameObject RightButtons;
    [SerializeField] GameObject PanelExit;
    //Button In Setting Screen

    //Sound Button Setting
    [SerializeField] Toggle ToggleMusic;
    [SerializeField] Toggle ToggleSFX;
    [SerializeField] GameObject listButton;


    Vector2 hotspot = Vector2.zero;
    public Texture2D cursonTexture;
    CursorMode cursorMode = CursorMode.Auto;
    public AudioMixer audioMixer;
    public TypeControllerGame typeControllerGame;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.None;
        ImagePressAnyKey.SetActive(true);
        PanelButtons.SetActive(false);
        // PanelSetting.SetActive(false);
        SetupLevelSpriteScreen();
        SetSelectListButton();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && gameState == GameState.None)
        {
            if (Input.GetMouseButtonDown(0)
              || Input.GetMouseButtonDown(1)
              || Input.GetMouseButtonDown(2))
                return; //Do Nothing
            Debug.Log("Press Any Key");
            gameState = GameState.Play;
            ImagePressAnyKey.SetActive(false);
            PanelButtons.SetActive(true);
            LogoGame.GetComponent<Animator>().SetBool("Move", true);
            MiddleButtons.GetComponent<Animator>().SetBool("Move", true);
            RightButtons.GetComponent<Animator>().SetBool("Move", true);

        }
        Cursor.SetCursor(cursonTexture, hotspot, cursorMode);

        //Debug.Log(Input.GetJoystickNames.ge);
    }

    public void StartGame()
    {
        OpenMapGame();

    }

    public void OpenSettingGame()
    {
        SetUnselectListButton();
        PanelSetting.gameObject.GetComponent<VerticalMainMenuXbox>().selectPanel();
        PanelSetting.GetComponent<Animator>().SetBool("Show", true);
        PanelSetting.gameObject.GetComponent<Animator>().SetBool("Hide", false);
        ShowSoundSettingInSetting();
    }
    public void CloseSettingGame()
    {
        SetSelectListButton();
        PanelSetting.GetComponent<VerticalMainMenuXbox>().unselectPanel();
        PanelSetting.GetComponent<Animator>().SetBool("Hide", true);
        PanelSetting.gameObject.GetComponent<Animator>().SetBool("Show", false);
    }
    public void OpenUpgradeGame()
    {
        SetUnselectListButton();
        PanelUpgrade.gameObject.GetComponent<VerticalMainMenuXbox>().selectPanel();
        //PanelUpgrade.SetActive(true);
        PanelUpgrade.gameObject.GetComponent<Animator>().SetBool("Show", true);
        PanelUpgrade.gameObject.GetComponent<Animator>().SetBool("Hide", false);
    }
    public void CloseUpgradeGame()
    {
        SetSelectListButton();
        PanelUpgrade.GetComponent<VerticalMainMenuXbox>().unselectPanel();
        //PanelUpgrade.SetActive(false);
        PanelUpgrade.gameObject.GetComponent<Animator>().SetBool("Hide", true);
        PanelUpgrade.gameObject.GetComponent<Animator>().SetBool("Show", false);
    }
    public void OpenMapGame()
    {
        SetUnselectListButton();
        PanelMapGame.SetActive(true);
        PanelMapGame.GetComponent<VerticalMainMenuXbox>().selectPanel();
    }
    public void HideMapGame()
    {
        SetSelectListButton();
        PanelMapGame.GetComponent<VerticalMainMenuXbox>().unselectPanel();
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

        for (int i = 0; i < currentLevel - 1; i++)
        {
            ButtonLevels[i].gameObject.GetComponent<LevelController>().SetStatusComplete();


        }
        for (int i = numberOfLevel - 1; i > currentLevel - 1; i--)
        {
            ButtonLevels[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        ButtonLevels[currentLevel - 1].gameObject.GetComponent<LevelController>().SetStatusAttackGame();
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void QuitGame()
    {

        SetUnselectListButton();
        PanelExit.gameObject.GetComponent<VerticalMainMenuXbox>().selectPanel();
        PanelExit.gameObject.GetComponent<Animator>().SetBool("Show", true);
        PanelExit.gameObject.GetComponent<Animator>().SetBool("Hide", false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void CancelExitGame()
    {
        SetSelectListButton();
        PanelExit.gameObject.GetComponent<VerticalMainMenuXbox>().unselectPanel();
        PanelExit.gameObject.GetComponent<Animator>().SetBool("Hide", true);
        PanelExit.gameObject.GetComponent<Animator>().SetBool("Show", false);
        //PanelExit.SetActive(false);
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
    public void SetVolumeMusic()
    {
        if (ToggleMusic.isOn == true)
        {
            audioMixer.SetFloat("Music", 0);
        }
        else
        {
            audioMixer.SetFloat("Music", -80);
        }
    }
    public void SetVolumeSFX()
    {
        if (ToggleSFX.isOn == true)
        {
            audioMixer.SetFloat("SFX", 0);
        }
        else
        {
            audioMixer.SetFloat("SFX", -80);
        }
    }
    public void BackToPressToStart()
    {

    }
    void SetSelectListButton()
    {
        listButton.GetComponent<VerticalMainMenuXbox>().selectPanel();
    }
    void SetUnselectListButton()
    {
        listButton.GetComponent<VerticalMainMenuXbox>().unselectPanel();
    }


}
