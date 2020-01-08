using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectController : MonoBehaviour
{
    public TypeControllerGame typeControllerGame;
    string[] names;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
