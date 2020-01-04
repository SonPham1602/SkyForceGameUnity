using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTrailEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] trails;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyTrailOfEnemy()
    {
        if(trails.Length>=0)
        for (int i = 0;i< trails.Length;i++)
        {
            Destroy(trails[i]);
        }
    }
}
