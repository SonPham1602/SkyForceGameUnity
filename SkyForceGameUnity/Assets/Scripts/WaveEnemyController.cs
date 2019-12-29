using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject[] waveEnemy;
    int currentWave;
    GameManager gameManager;
    public bool StartWave;// kiem luon bool cua first Wave
    public float Timedelay;// thoi gian delay giua cac wave voi nhau
    public void StartWaveEnenmy()
    {
        StartWave = true;
        
    }
     
    IEnumerator Start()
    {
        if (waveEnemy.Length == 0)
        {
            yield break;
        }
        gameManager = FindObjectOfType<GameManager>();
        while (true)
        {
            //Chan khong cho bat dau
            //Muc dich la de chan ko tu bat dau o wave tiep theo
            while (StartWave == false )
            {
                yield return 0;
            }
            while (gameManager.gameState != GameState.Play)
            {

                yield return 0;
            }
          
           
            //   Debug.Log("current wave:"+currentWave);
            if (currentWave < waveEnemy.Length)
            {
                GameObject wave = (GameObject)Instantiate(waveEnemy[currentWave], transform.position, Quaternion.identity);
                wave.transform.parent = transform;
                while (0 < wave.transform.childCount)
                {
                    //Debug.Log("childCount"+wave.transform.childCount);
                    yield return 0;
                }
                Destroy(wave);

            }
            else
            {
                yield return 0;
            }
            currentWave++;
            if (currentWave >= waveEnemy.Length)
            {
                // time deplay giua cac way
                yield return new WaitForSeconds(Timedelay);
                WaveEnemyController[] wave = FindObjectsOfType<WaveEnemyController>();
                wave[0].StartWaveEnenmy();
                if (wave.Length <= 1)
                {
                    //gameManager.gameWin();
                }
                
               
                Destroy(gameObject);
            }
        }
    }
}
