using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHostController : PlayerController
{
    public Player user;
    public static PlayerHostController Instance;

    void Start() {
        Instance = this;
        base.Start();
        isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
