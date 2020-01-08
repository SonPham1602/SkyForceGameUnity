using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHostController : PlayerController
{
    public Player user;
    public static PlayerHostController Instance;
    private Vector3 oldPosition;

    void Start() {
        Instance = this;
        base.Start();
        isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (transform.position != oldPosition && OnlineGameController.Instance.startGame) {
            SocketClient.Instance.AddMessage(MessageWriter.getMessageChangePosition(0, transform.position));
            oldPosition = transform.position;
        }
    }
}
