﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum TypeXboxGamepad
{
    VerticalGamepad,
    HorizontalGamepad
}
public enum TypeControllerGamepad
{
    JoystickController,
    LRBController
}
public class VerticalMainMenuXbox : MonoBehaviour
{
    public bool dontHaveFunctionEventClick;
    bool selectedPanel;
    [SerializeField] GameObject[] listButton;
    public int select;
    private DetectController detectController;
    private SoundController soundController;
    [SerializeField] TypeXboxGamepad typeXboxGamepad;
    public UnityEvent eventBack;
    private bool check;
    public TypeControllerGamepad typeControllerGamepad;



    // Start is called before the first frame update
    void Start()
    {

        detectController = GameObject.FindObjectOfType<DetectController>();
        soundController = GameObject.FindObjectOfType<SoundController>();



        if (GameSetting.typeControllerGame == TypeControllerGame.GamePad && listButton.Length != 0)
        {
            Debug.Log("Check");
            UnpressAllButton();
            listButton[select].GetComponent<ButtonInSetting>().SetPressedSprite();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (selectedPanel == true)
        {
            if (detectController.typeControllerGame == TypeControllerGame.GamePad)
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
                            UnpressAllButton();
                            soundController.PlaySoundSwith();
                            listButton[select].GetComponent<ButtonInSetting>().SetPressedSprite();

                            check = false;
                        }

                    }
                    else if (updowncheck < 0)
                    {
                        if (select < listButton.Length - 1 && check == true)
                        {
                            Debug.Log("down");
                            select++;
                            UnpressAllButton();
                            soundController.PlaySoundSwith();
                            listButton[select].GetComponent<ButtonInSetting>().SetPressedSprite();
                            check = false;
                        }

                    }
                    else if (updowncheck == 0)
                    {
                        check = true;
                        // Debug.Log("stand");
                    }
                    //Debug.Log(select);
                }
                else if (typeXboxGamepad == TypeXboxGamepad.HorizontalGamepad)
                {
                    if (typeControllerGamepad == TypeControllerGamepad.JoystickController)
                    {
                        float updowncheck = Input.GetAxis("Horizontal");
                        if (updowncheck < 0)
                        {
                            if (select >= 1 && check == true)
                            {

                                Debug.Log("right");
                                select--;
                                if (listButton[0].GetComponent<ButtonInSetting>() != null)
                                {
                                    UnpressAllButton();
                                    listButton[select].GetComponent<ButtonInSetting>().SetPressedSprite();
                                }

                                soundController.PlaySoundSwith();

                                check = false;
                            }

                        }
                        else if (updowncheck > 0)
                        {
                            if (select < listButton.Length - 1 && check == true)
                            {
                                Debug.Log("left");
                                select++;
                                if (listButton[0].GetComponent<ButtonInSetting>() != null)
                                {
                                    UnpressAllButton();
                                    listButton[select].GetComponent<ButtonInSetting>().SetPressedSprite();
                                }


                                soundController.PlaySoundSwith();

                                check = false;
                            }

                        }
                        else if (updowncheck == 0)
                        {
                            check = true;
                            // Debug.Log("stand");
                        }
                       // Debug.Log(select);
                    }
                    else if (typeControllerGamepad == TypeControllerGamepad.LRBController)
                    {
                        if (Input.GetKeyDown("joystick button 5"))
                        {
                            Debug.Log("Right");
                            if (select < listButton.Length - 1)
                            {
                                select++;
                                UnpressAllButton();
                                soundController.PlaySoundSwith();
                                listButton[select].GetComponent<ButtonInSetting>().SetPressedSprite();
                            }
                        }
                        else if (Input.GetKeyDown("joystick button 4"))
                        {
                            if (select >= 1)
                            {
                                select--;
                                UnpressAllButton();
                                soundController.PlaySoundSwith();
                                listButton[select].GetComponent<ButtonInSetting>().SetPressedSprite();
                            }
                            Debug.Log("Left");
                        }
                    }


                }
                if (dontHaveFunctionEventClick == false)
                {
                    if (Input.GetKeyDown("joystick button 0"))
                    {
                        listButton[select].GetComponent<Button>().onClick.Invoke();
                    }
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
    void UnpressAllButton()
    {
        if (listButton.Length != 0)
        {
            for (int i = 0; i < listButton.Length; i++)
            {
                listButton[i].GetComponent<ButtonInSetting>().SetUnPressedSprite();
            }
        }

    }


}
