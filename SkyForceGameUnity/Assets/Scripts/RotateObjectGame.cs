﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectGame : MonoBehaviour
{
    public float speedSpin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, transform.rotation.z + speedSpin );
    }
}
