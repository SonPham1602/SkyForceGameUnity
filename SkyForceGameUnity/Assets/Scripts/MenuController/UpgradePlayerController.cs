using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradePlayerController : MonoBehaviour
{

    [SerializeField] Sprite upgradeSprite;
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
    public void UpItem()
    {
        image.sprite = upgradeSprite;
    }
    public void DownItem()
    {
        image.sprite = sprite;
    }
  
}
