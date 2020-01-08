using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapGameController : MonoBehaviour
{
    [SerializeField] VerticalMainMenuXbox verticalMainMenuXbox;
    public int currentLevel;
    public int numberOfLevel;
    public GameObject[] ButtonLevels;

    // Start is called before the first frame update
    void Start()
    {
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
}
