using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeImageGamepadToKeyboard : MonoBehaviour
{
    [SerializeField] Sprite gamepadImage;
    [SerializeField] Sprite keyboardImage;
    [SerializeField] Image image;

    // Start is called before the first frame update
    void Start()
    {
        if(GameSetting.typeControllerGame == TypeControllerGame.GamePad)
        {
            ChangeKeyboardToGamepad();
        }
        else if(GameSetting.typeControllerGame == TypeControllerGame.MouseAndKeyboard)
        {
            ChangeGamepadToKeyboard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameSetting.typeControllerGame == TypeControllerGame.GamePad)
        {
            ChangeKeyboardToGamepad();
        }
        else if(GameSetting.typeControllerGame == TypeControllerGame.MouseAndKeyboard)
        {
            ChangeGamepadToKeyboard();
        }
    }
    public void ChangeGamepadToKeyboard()
    {
        image.sprite = keyboardImage;
    }
    
    public void ChangeKeyboardToGamepad()
    {
        image.sprite = gamepadImage;
    }   
}
