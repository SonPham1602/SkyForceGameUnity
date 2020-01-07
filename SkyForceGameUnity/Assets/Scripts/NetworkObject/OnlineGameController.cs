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
    private GameObject SelectModePanel, RegisterPlayerPanel, JoinRoomPanel, HostWatingPanel, NotifyPanel;

    [SerializeField]
    private Text txtPlayerName, txtRoomId, txtMessageNotify;

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
        DontDestroyOnLoad(this);
        oldTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startGame)
        {
            oldTime = Time.time;
        }
        else if (Time.time - oldTime >= 5)
        {
            GameObject.FindObjectOfType<GameManager>().gameState = GameState.Play;
        }
    }

    public void StartGame()
    {
        startGame = true;
    }

    public void AddNetworkPlayer(Player player)
    {
        HostWatingPanel.SetActive(false);
        PlayerNetworkController.Instance.user = player;
        StartGame();
    }

    public void AddPlayerHost(int id)
    {
        PlayerHostController.Instance.user = new Player() { id = id, name = namePlayer };
        txtPlayerName.text = namePlayer;
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
        txtRoomId.text = roomId.ToString();
        SelectModePanel.SetActive(false);
        HostWatingPanel.SetActive(true);
    }

    public void StartClient()
    {
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
        JoinRoomPanel.SetActive(false);
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
