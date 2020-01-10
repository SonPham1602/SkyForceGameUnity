using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public static LevelOfBulletPlayer levelOfBulletPlayer;
    public static LevelOfHealthPlayer levelOfHealthPlayer;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpLevelOfBulletPlayer()
    {
        levelOfBulletPlayer ++;
    }
     public void UpLevelHealthPlayer()
    {
        levelOfHealthPlayer ++;
    }
}
