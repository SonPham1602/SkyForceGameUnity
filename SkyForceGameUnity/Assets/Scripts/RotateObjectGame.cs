using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectGame : MonoBehaviour
{
    public int speedSpin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
            transform.Rotate(Vector3.forward*speedSpin*Time.deltaTime);
        
    }
}
