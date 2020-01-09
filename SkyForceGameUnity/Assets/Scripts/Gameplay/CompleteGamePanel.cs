using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteGamePanel : MonoBehaviour
{
    public int numberScore;
    public int numberStar;

    public Sprite oneStar;
    public Sprite twoStar;
    public Sprite threeStar;

    [SerializeField] GameObject numberMissionComplete;
    [SerializeField] GameObject textScore;
    [SerializeField] GameObject textStar;
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale=0;

    }

    // Update is called once per frame
    void Update()
    {
        textScore.GetComponent<Text>().text = numberScore.ToString();
        textStar.GetComponent<Text>().text = numberStar.ToString();
        if (GameSetting.typeControllerGame == TypeControllerGame.GamePad)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                GameObject.FindObjectOfType<GameManager>().GoToMapGame();
            }
            else if (Input.GetKeyDown("joystick button 3"))
            {
                GameObject.FindObjectOfType<GameManager>().ResetLevel();
            }

        }
        else if (GameSetting.typeControllerGame == TypeControllerGame.MouseAndKeyboard)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameObject.FindObjectOfType<GameManager>().ResetLevel();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                GameObject.FindObjectOfType<GameManager>().GoToMapGame();
            }
        }
    }

    public void SetupPanelCompleteGame(int score, int star, int numberMission)
    {
        
        numberScore = score;
        numberStar = star;
        if (numberMission == 1)
        {
            numberMissionComplete.gameObject.GetComponent<Image>().sprite = oneStar;
        }
        else if (numberMission == 2)
        {
            numberMissionComplete.gameObject.GetComponent<Image>().sprite = twoStar;
        }
        else if (numberMission == 3)
        {
            numberMissionComplete.gameObject.GetComponent<Image>().sprite = threeStar;
        }
    }

}
