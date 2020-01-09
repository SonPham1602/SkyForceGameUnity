using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

class playerInformation
{
    string Name;
}
class shipInformation
{
    int level;


}
public enum TypeOfModeDev
{
    hack,
    normal
}
public class SaveGame : MonoBehaviour
{
    public int currentLevelComplete;
    public TypeOfModeDev typeOfModeDev;
    public bool SoundInGame;
    public bool MusicInGame;
    public string ResolutionInGame;
    public string GraphicInGame;
    public int numberOfStar;

    public List<LevelInfomation> levelInfomations = new List<LevelInfomation>();
    // Start is called before the first frame update
    void Start()
    {
        if(typeOfModeDev == TypeOfModeDev.hack)
        {
            CreateDataGameSave();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SaveSettingSound()
    {
        if (SoundInGame == true)
        {
            PlayerPrefs.SetString("SoundInGame", "true");
        }
        else
        {
            PlayerPrefs.SetString("SoundInGame", "false");
        }

    }
    public bool GetSettingSound()
    {
        string str = PlayerPrefs.GetString("SoundInGame");
        if(str == "true")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

     public void SaveSettingMusic()
    {
        if (MusicInGame == true)
        {
            PlayerPrefs.SetString("MusicInGame", "true");
        }
        else
        {
            PlayerPrefs.SetString("MusicInGame", "false");
        }

    }
    public bool GetSettingMusic()
    {
        string str = PlayerPrefs.GetString("MusicInGame");
        if(str == "true")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SaveLevel(int n)
    {
        
        string str = "Level" + (n + 1).ToString() + "Star";
        PlayerPrefs.SetInt(str, levelInfomations[n].numberOfStar);
        str = "Level" + (n + 1).ToString() + "Score";
        PlayerPrefs.SetInt(str, levelInfomations[n].score);
    }
    public LevelInfomation GetLevelGame(int n)
    {
        LevelInfomation levelInfomation = new LevelInfomation();
        string str = "Level" + (n + 1).ToString() + "Star";
        levelInfomation.numberOfStar = PlayerPrefs.GetInt(str);
        str = "Level" + (n + 1).ToString() + "Score";
        levelInfomation.score = PlayerPrefs.GetInt(str);
        return  levelInfomation;
    }
    public void CreateDataGameSave()
    {
        currentLevelComplete = 3;
        levelInfomations.Add(new LevelInfomation(1,true,false,false,1111,TypeOfLevelGame.Complete));
        levelInfomations.Add(new LevelInfomation(2,true,true,false,1111,TypeOfLevelGame.Complete));
        levelInfomations.Add(new LevelInfomation(3,true,true,true,1111,TypeOfLevelGame.Complete));
        levelInfomations.Add(new LevelInfomation(1,true,false,false,1111,TypeOfLevelGame.Complete));
        levelInfomations.Add(new LevelInfomation(0,true,false,false,1111,TypeOfLevelGame.Lock));
        levelInfomations.Add(new LevelInfomation(0,true,false,false,1111,TypeOfLevelGame.Lock));
        numberOfStar=99999;
    }
    public void SaveNumberStar()
    {
        PlayerPrefs.SetInt("NumberOfStar",numberOfStar);
    }


}
