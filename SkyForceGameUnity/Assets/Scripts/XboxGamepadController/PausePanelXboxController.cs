using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanelXboxController : MonoBehaviour
{
    [SerializeField] GameObject[] listButton;
    private int select;
    // Start is called before the first frame update
    void Start()
    {
        select = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameSetting.typeControllerGame == TypeControllerGame.GamePad)
        {
            if(Input.GetKeyDown("joystick button 5"))
            {
                Debug.Log("Right");
                if(select<listButton.Length-1)
                {
                    select ++;
                    UnpressAllButton();
                    listButton[select].GetComponent<ButtonInSetting>().SetPressedSprite();
                }
            }
            else if(Input.GetKeyDown("joystick button 4"))
            {
                 if(select>=1)
                {
                    select --;
                    UnpressAllButton();
                    listButton[select].GetComponent<ButtonInSetting>().SetPressedSprite();
                }
                Debug.Log("Left");
            }
//            Debug.Log("Select" + select);
            if(Input.GetKeyDown("joystick button 0"))
            {
                listButton[select].GetComponent<Button>().onClick.Invoke();
            }
           
        }
    }
    void UnpressAllButton()
    {
        for(int i=0;i<listButton.Length;i++)
        {
            listButton[i].GetComponent<ButtonInSetting>().SetUnPressedSprite();
        }
    }
}
