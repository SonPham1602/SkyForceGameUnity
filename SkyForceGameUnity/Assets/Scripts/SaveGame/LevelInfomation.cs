using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeOfLevelGame
{
    Complete,
    Lock
}
public class LevelInfomation
{
    public LevelInfomation()
    {
    
    }
    public LevelInfomation(int nbStar,bool isMission1,bool isMission2, bool isMission3,int scoreGame,TypeOfLevelGame type)
    {
        numberOfStar = nbStar;
        mission1 = isMission1 ;
        mission2 = isMission2;
        mission3 = isMission3;
        score = scoreGame;
        typeOfLevelGame = type;
    }
    public TypeOfLevelGame typeOfLevelGame;
   public int numberOfStar;
   public bool mission1;
   public bool mission2;
   public bool mission3;
   public int score;
    // Start is called before the first frame update
}
