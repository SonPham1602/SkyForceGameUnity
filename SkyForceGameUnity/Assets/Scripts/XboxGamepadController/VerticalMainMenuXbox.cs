using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum TypeXboxGamepad
{
    VerticalGamepad,
    HorizontalGamepad
}
public class VerticalMainMenuXbox : MonoBehaviour
{
    bool selectedPanel;
    [SerializeField] GameObject[] listButton;
    private int select;
    private MainMenuController mainMenuController;
    [SerializeField] TypeXboxGamepad typeXboxGamepad;
    public UnityEvent eventBack;
    private bool check;


    // Start is called before the first frame update
    void Start()
    {
        select = 1;
        mainMenuController = GameObject.FindObjectOfType<MainMenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedPanel == true)
        {
            if (mainMenuController.typeControllerGame == TypeControllerGame.GamePad)
            {
                if (typeXboxGamepad == TypeXboxGamepad.VerticalGamepad)
                {
                    float updowncheck = Input.GetAxis("Vertical");
                    if (updowncheck > 0)
                    {
                        if (select >= 1 && check == true)
                        {
                            Debug.Log("up");
                            select--;
                            check = false;
                        }

                    }
                    else if (updowncheck < 0)
                    {
                        if (select < listButton.Length - 1 && check == true)
                        {
                            Debug.Log("down");
                            select++;
                            check = false;
                        }

                    }
                    else if (updowncheck == 0)
                    {
                        check = true;
                        Debug.Log("stand");
                    }
                    Debug.Log(select);
                }
                else if (typeXboxGamepad == TypeXboxGamepad.HorizontalGamepad)
                {
                    float updowncheck = Input.GetAxis("Horizontal");
                    if (updowncheck > 0)
                    {
                        if (select >= 1)
                        {
                            Debug.Log("right");
                            select--;
                        }

                    }
                    else if (updowncheck < 0)
                    {
                        if (select < listButton.Length - 1)
                        {
                            Debug.Log("left");
                            select++;
                        }

                    }
                }

                if (Input.GetKeyDown("joystick button 0"))
                {
                    listButton[select].GetComponent<Button>().onClick.Invoke();
                }
                if (Input.GetKeyDown("joystick button 1"))
                {
                    eventBack.Invoke();
                }
                //Debug.Log(updowncheck);

            }
        }


    }

    public void selectPanel()
    {
        selectedPanel = true;
    }

    public void unselectPanel()
    {
        selectedPanel = false;
    }

}
