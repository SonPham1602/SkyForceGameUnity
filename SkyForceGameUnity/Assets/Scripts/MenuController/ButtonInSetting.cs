using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInSetting : MonoBehaviour
{
    [SerializeField] Sprite spritePressed;
    [SerializeField] Sprite sprite;
    [SerializeField] Image image;
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }
    public void SetPressedSprite()
    {
        image.sprite = spritePressed;
    }
      public void SetUnPressedSprite()
    {
        image.sprite = sprite;
    }
   
}
