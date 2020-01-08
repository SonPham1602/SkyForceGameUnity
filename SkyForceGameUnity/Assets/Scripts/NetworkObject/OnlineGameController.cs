using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class OnlineGameController : MonoBehaviour
{
    [SerializeField]
    private float timeStart;

    [SerializeField]
    private GameObject SelectModePanel, RegisterPlayerPanel, JoinRoomPanel,
                    HostWatingPanel, NotifyPanel, DisplayPlayerHostName, DisplayPlayerNetworkName;

    [SerializeField]
    private GameObject buttonExitHostWaiting;

    [SerializeField]
    private Text txtPlayerName, txtRoomId, txtMessageNotify, txtPlayerNameWating, txtPlayerNetworkName, txtCountDown;

    [SerializeField]
    private InputField edtPlayerName, edtRoomId;

    public bool isHost, startGame;
    public short roomId;
    public static OnlineGameController Instance;

    private float oldTime;
    private string namePlayer;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        oldTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {}

    public void StartGame()
    {
        HostWatingPanel.SetActive(false);
        startGame = true;
        GameObject.FindObjectOfType<GameManager>().gameState = GameState.Play;
    }

    IEnumerator CountDownStartGame()
    {
        int i = 0;
        while (i < 5)
        {
            txtCountDown.text = "" + (5 - i);
            yield return new WaitForSeconds(1);
            i++;
        }
        StartGame();
    }

    public void AddNetworkPlayer(Player player)
    {
        JoinRoomPanel.SetActive(false);
        HostWatingPanel.SetActive(true);
        PlayerNetworkController.Instance.user = player;
        txtPlayerNetworkName.text = player.name;
        DisplayPlayerNetworkName.SetActive(true);
        buttonExitHostWaiting.SetActive(false);
        txtCountDown.gameObject.SetActive(true);
        StartCoroutine(CountDownStartGame());
    }

    public void AddPlayerHost(int id)
    {
        PlayerHostController.Instance.user = new Player() { id = id, name = namePlayer };
        txtPlayerName.text = namePlayer;
        txtPlayerNameWating.text = namePlayer;
        RegisterPlayerPanel.SetActive(false);
        SelectModePanel.SetActive(true);
    }

    public void RegisterPlayer()
    {
        this.namePlayer = edtPlayerName.text;
        SocketClient.Instance.AddMessage(MessageWriter.registerPlayer(namePlayer));
    }

    public void RegisterPlayerFailed()
    {
        txtMessageNotify.text = "Tên người chơi đã tồn tại";
        NotifyPanel.SetActive(true);
    }

    public void StartHost()
    {
        isHost = true;
        SocketClient.Instance.AddMessage(MessageWriter.createRoomMessage());
    }

    public void CreateRoomSuccess(short roomId)
    {
        this.roomId = roomId;
        txtRoomId.text = "ROOM " + roomId.ToString();
        DisplayPlayerHostName.SetActive(true);
        DisplayPlayerNetworkName.SetActive(false);
        SelectModePanel.SetActive(false);
        HostWatingPanel.SetActive(true);
    }

    public void StartClient()
    {
        isHost = false;
        SelectModePanel.SetActive(false);
        JoinRoomPanel.SetActive(true);
    }

    public void JoinRoom()
    {
        this.roomId = Int16.Parse(edtRoomId.text);
        SocketClient.Instance.AddMessage(MessageWriter.getMessageJoinRoom(this.roomId));
    }

    public void JoinRoomSuccess()
    {
        SocketClient.Instance.AddMessage(MessageWriter.getPlayerInRoomMessage());
    }

    public void JoinRoomFailed(byte status)
    {
        if (status == 1)
        {
            txtMessageNotify.text = "Phòng đã đầy";
        }
        else if (status == 2)
        {
            txtMessageNotify.text = "Phòng không tồn tại";
        }
        NotifyPanel.SetActive(true);
    }

    public void HideNotifyPanel()
    {
        NotifyPanel.SetActive(false);
    }

    public void PlayerLeftRoom()
    {
        DestroyObject(PlayerNetworkController.Instance.gameObject);
    }

}
