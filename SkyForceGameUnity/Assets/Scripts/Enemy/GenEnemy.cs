using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject[] _Waves;
    int _CurrentWave;
    GameManager _gameManager;
    public bool loop;
  

    // Update is called once per frame
    
    IEnumerator Start() {
        if(_Waves.Length == 0)
        {
            yield break;
        }
        _gameManager = FindObjectOfType<GameManager>();
        while (true)
        {
            while (_gameManager.gameState != GameState.Play)
            {
                yield return 0;
            }
            if (_CurrentWave < _Waves.Length)
            {
                GameObject wave = (GameObject)Instantiate(_Waves[_CurrentWave], transform.position, Quaternion.identity);
                wave.transform.parent = transform;
                while (0 < wave.transform.childCount)
                {
                    yield return 0;

                }
                Destroy(wave);
            }
            else
            {
                yield return 0;
            }
            if (loop)
                _CurrentWave = (int)Mathf.Repeat(_CurrentWave + 1f, _Waves.Length);
            else
            {
                _CurrentWave++;

                if (_CurrentWave >= _Waves.Length)
                {
                    GenEnemy[] wave = FindObjectsOfType<GenEnemy>();
                    if (wave.Length <= 1)
                    {
                        _gameManager.gameWin();
                    }
                    Destroy(gameObject);
                }
            }
        }
       
    }
}
