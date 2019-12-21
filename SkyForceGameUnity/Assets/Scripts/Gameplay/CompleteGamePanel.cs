using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteGamePanel : MonoBehaviour
{
    public int numberScore;
    public int numberStar;
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
        
    }

    public void SetupPanelCompleteGame(int score,int star)
    {
        textScore.GetComponent<Text>().text = score.ToString();
        textStar.GetComponent<Text>().text = star.ToString();
    }
}
