using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject[] waveEnemy;
    int currentWave;
    GameManager gameManager;
  
   
    IEnumerator Start() {
        if(waveEnemy.Length == 0)
        {
            yield break;
        }
        gameManager = FindObjectOfType<GameManager>();
        while (true)
        {
            Debug.Log("current wave:"+currentWave);
            if(currentWave<waveEnemy.Length)
            {
                GameObject wave = (GameObject)Instantiate(waveEnemy[currentWave],transform.position,Quaternion.identity);
                wave.transform.parent = transform;
                while(0<wave.transform.childCount)
                {
                    Debug.Log("childCount"+wave.transform.childCount);
                    yield return 0;
                }
                Destroy(wave);

            }
            else
            {
                yield return 0;
            }
            currentWave++;
            if(currentWave>=waveEnemy.Length)
            {
                Destroy(gameObject);
            }
        }
    }
}
