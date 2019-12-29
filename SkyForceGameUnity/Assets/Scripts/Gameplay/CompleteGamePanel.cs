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
        textScore.GetComponent<Text>().text = numberScore.ToString();
        textStar.GetComponent<Text>().text = numberStar.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameSetting.typeControllerGame == TypeControllerGame.GamePad)
        {

        }
        else if(GameSetting.typeControllerGame==TypeControllerGame.MouseAndKeyboard)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                GameObject.FindObjectOfType<GameManager>().ResetLevel();
            }
            else if(Input.GetKeyDown(KeyCode.Return))
            {
                GameObject.FindObjectOfType<GameManager>().GoToMapGame();
            }
        }
    }

    public void SetupPanelCompleteGame(int score, int star, int numberMission)
    {
        textScore.GetComponent<Text>().text = score.ToString();
        textStar.GetComponent<Text>().text = star.ToString();
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
