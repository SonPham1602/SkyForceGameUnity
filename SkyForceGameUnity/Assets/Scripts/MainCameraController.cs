using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public float speedMove;
    public Renderer bgRend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //transform.position = new Vector3(transform.position.x,transform.position.y-1*Time.deltaTime*2,transform.position.z);
        bgRend.material.mainTextureOffset+= new Vector2(0f,speedMove*Time.deltaTime);
    }
    public void PauseAnimation()
    {
        speedMove=0;
    }
}
