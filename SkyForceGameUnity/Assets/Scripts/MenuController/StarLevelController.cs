using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarLevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite star1;
    public Sprite star2;
    public Sprite star3;
    public Image img ;
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetStar(int n)
    {
        if(n==1)
        {
            img.sprite = star1;
        }
        else if(n==2)
        {
             img.sprite = star2;
        }
        else if(n==3)
        {
              img.sprite = star3;
        }
    }
}
