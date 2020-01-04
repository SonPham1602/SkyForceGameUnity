using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuXbox : MonoBehaviour
{
    [SerializeField] GameObject[] listButton;
    private int select;
    private MainMenuController mainMenuController;
    // Start is called before the first frame update
    void Start()
    {
        select = 0;
        mainMenuController = GameObject.FindObjectOfType<MainMenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainMenuController.typeControllerGame == TypeControllerGame.GamePad)
        {

            float updowncheck = Input.GetAxis("Vertical");
            if (updowncheck > 0)
            {
                if (select >= 1)
                {
                    Debug.Log("up");
                    select--;
                }

            }
            else if (updowncheck < 0)
            {
                if (select < listButton.Length - 1)
                {
                    Debug.Log("down");
                    select++;
                }

            }
            if (Input.GetKeyDown("joystick button 0"))
            {
                listButton[select].GetComponent<Button>().onClick.Invoke();
            }
            //Debug.Log(updowncheck);

        }

    }
}
