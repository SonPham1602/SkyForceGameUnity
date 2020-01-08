using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public SaveGame saveGame;
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
    string[] names;// name of controller
    private SoundController soundController;

    // Start is called before the first frame update
    void Start()
    {

        //Set up Load Save game
        currentLevel=saveGame.currentLevelComplete;
        soundController = GameObject.FindObjectOfType<SoundController>();
        Time.timeScale = 1f;
        Debug.Log("Khoi tao" + gameState.ToString());
        gameState = GameState.None;
        ImagePressAnyKey.SetActive(true);
        ImagePressAnyKey.GetComponent<Animator>().enabled = false;
        ImagePressAnyKey.GetComponent<Animator>().enabled = true;
        ImagePressAnyKey.GetComponent<Animator>().Play("PressAnyKey");
        PanelButtons.SetActive(false);
        // PanelSetting.SetActive(false);
        //SetupLevelSpriteScreen();
        SetSelectListButton();

        names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            // print(names[x].Length);
            if (names[x].Length == 33)
            {
                // Debug.Log("Xbox 360 Connected");
                typeControllerGame = TypeControllerGame.GamePad;
            }
            else
            {
                typeControllerGame = TypeControllerGame.MouseAndKeyboard;
            }

        }
    }

    // Update is called once per frame

    private int Xbox_One_Controller = 0;
    private int PS4_Controller = 0;
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
        names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            // print(names[x].Length);
            if (names[x].Length == 33)
            {
                //Debug.Log("Xbox 360 Connected");
                typeControllerGame = TypeControllerGame.GamePad;
            }
            else
            {
                typeControllerGame = TypeControllerGame.MouseAndKeyboard;
            }

        }



        //Debug.Log(Input.GetJoystickNames.ge);
    }

    public void StartGame()
    {
        OpenMapGame();

    }

    public void OpenSettingGame()
    {
        soundController.PlaySoundPress();
        SetUnselectListButton();
        PanelSetting.gameObject.GetComponent<VerticalMainMenuXbox>().selectPanel();
        PanelSetting.GetComponent<Animator>().SetBool("Show", true);
        PanelSetting.gameObject.GetComponent<Animator>().SetBool("Hide", false);
        ShowSoundSettingInSetting();
    }
    public void CloseSettingGame()
    {
        soundController.PlaySoundBack();
        SetSelectListButton();
        PanelSetting.GetComponent<VerticalMainMenuXbox>().unselectPanel();
        PanelSetting.GetComponent<Animator>().SetBool("Hide", true);
        PanelSetting.gameObject.GetComponent<Animator>().SetBool("Show", false);
    }
    public void OpenUpgradeGame()
    {
        soundController.PlaySoundPress();
        SetUnselectListButton();
        PanelUpgrade.gameObject.GetComponent<VerticalMainMenuXbox>().selectPanel();
        //PanelUpgrade.SetActive(true);
        PanelUpgrade.gameObject.GetComponent<Animator>().SetBool("Show", true);
        PanelUpgrade.gameObject.GetComponent<Animator>().SetBool("Hide", false);
    }
    public void CloseUpgradeGame()
    {

        soundController.PlaySoundBack();
        SetSelectListButton();
        PanelUpgrade.GetComponent<VerticalMainMenuXbox>().unselectPanel();
        //PanelUpgrade.SetActive(false);
        PanelUpgrade.gameObject.GetComponent<Animator>().SetBool("Hide", true);
        PanelUpgrade.gameObject.GetComponent<Animator>().SetBool("Show", false);
    }
    public void OpenMapGame()
    {
        soundController.PlaySoundPress();
        SetUnselectListButton();
        PanelMapGame.SetActive(true);
        PanelMapGame.GetComponent<VerticalMainMenuXbox>().selectPanel();
    }
    public void HideMapGame()
    {
        soundController.PlaySoundBack();
        SetSelectListButton();
        PanelMapGame.GetComponent<VerticalMainMenuXbox>().unselectPanel();
        PanelMapGame.SetActive(false);

    }
    public void OpenShopGame()
    {

    }
    public void QuitGame()
    {
        soundController.PlaySoundPress();
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
        soundController.PlaySoundBack();
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
