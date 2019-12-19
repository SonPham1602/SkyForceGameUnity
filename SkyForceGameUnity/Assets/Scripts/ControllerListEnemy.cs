using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerListEnemy : MonoBehaviour
{
    private bool startMove;
    public float speedMove;
    // Start is called before the first frame update
    void Start()
    {
        startMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startMove == true)
        {
            transform.position = new Vector2(transform.position.x,transform.position.y+speedMove*Time.deltaTime);
        }
        
    }
    public void StopMovingListEnemy()
    {
        speedMove = 0f;
    }
    public void StartOrCountinueMovingEnemy()
    {
        startMove = true;
    }
}
