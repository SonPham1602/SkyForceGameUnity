using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSettingController : MonoBehaviour
{
    [SerializeField] GameObject toggleFullscreen;
    [SerializeField] GameObject Resolution;
    [SerializeField] GameObject Graphics;
    int currentResolution;
    FullScreenMode fullScreenMode;
    string[] listResolution = { "800 x 600", "1024 x 768", "1280 x 960", "1600 x 900", "1920 x 1080" };
    int[,] listResolutionArray = {
            {800, 600},
            {1024, 768},
            {1280, 960},
            {1600,900},
            {1920,1080}
        };
    // Start is called before the first frame update
    void Start()
    {
        fullScreenMode= FullScreenMode.Windowed;
        currentResolution = 0;
    }

    // Update is called once per frame-
    void Update()
    {

    }
    public void SetFullScreen()
    {

    }
    public void LeftResolution()
    {

        if (currentResolution > 0)
        {
            currentResolution--;
            Screen.SetResolution(listResolutionArray[currentResolution, 0], listResolutionArray[currentResolution, 1], fullScreenMode);
            Resolution.gameObject.GetComponent<Text>().text = listResolution[currentResolution];
        }

    }
    public void RightResolution()
    {
        if (currentResolution < listResolution.Length-1)
        {
            currentResolution++;
            Screen.SetResolution(listResolutionArray[currentResolution, 0], listResolutionArray[currentResolution, 1], fullScreenMode);
            Resolution.gameObject.GetComponent<Text>().text = listResolution[currentResolution];
        }

    }
}
