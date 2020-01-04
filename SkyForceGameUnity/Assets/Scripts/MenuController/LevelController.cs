using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelController : MonoBehaviour
{
   
    public Sprite AttackGame;
    public Sprite CompleteGame;
    public Sprite LockGame;
    [SerializeField] Image image;

    // Start is called before the first frame update
    void Start()
    {
        image.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetStatusComplete()
    {
        image.sprite = CompleteGame;
    }
     public void SetStatusLockGame()
    {
        image.sprite = LockGame;
    }

     public void SetStatusAttackGame()
    {
        image.sprite = AttackGame;
    }
}
