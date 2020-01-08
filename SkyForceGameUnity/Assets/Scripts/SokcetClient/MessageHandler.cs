using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class MessageHandler
{
    public static void onMessage(Message message)
    {
        BinaryReaderConverter binaryReader = new BinaryReaderConverter(message.Data);
        switch (message.Command)
        {
            case MessageCode.HANSAKE_CODE:
                Debug.Log("Data of hansake " + Encoding.ASCII.GetString(message.Data));
                break;
            case MessageCode.CHANGE_POSITION_CODE:
                byte direction = binaryReader.ReadByte();
                float xPos = binaryReader.ReadSingle();
                float yPos = binaryReader.ReadSingle();
                UnityMainThread.wkr.AddJob(new Action(() =>
                {
                    PlayerNetworkController.Instance.AddNewPosition(new Vector3(xPos, yPos, 0));
                }));
                break;
            case MessageCode.PLAYER_JOIN_AREROOM_CODE:
            case MessageCode.GET_PLAYER_IN_ROOM:
                short size = binaryReader.ReadInt16();
                string userInfo = Encoding.ASCII.GetString(binaryReader.ReadBytes(size));
                Player player = JsonUtility.FromJson<Player>(userInfo);
                UnityMainThread.wkr.AddJob(new Action(() =>
                {
                    OnlineGameController.Instance.AddNetworkPlayer(player);
                }));
                break;
            case MessageCode.REGISTER_PLAYER:
                byte status = binaryReader.ReadByte();
                if (status == 1)
                {
                    short id = binaryReader.ReadInt16();
                    UnityMainThread.wkr.AddJob(new Action(() =>
                    {
                        OnlineGameController.Instance.AddPlayerHost(id);
                    }));
                }
                else
                {
                    UnityMainThread.wkr.AddJob(new Action(() =>
                    {
                        OnlineGameController.Instance.RegisterPlayerFailed();
                    }));
                }

                break;
            case MessageCode.JOIN_ROOM_CODE:
                byte result = binaryReader.ReadByte();
                if (result == 0)
                {
                    UnityMainThread.wkr.AddJob(new Action(() =>
                    {
                        OnlineGameController.Instance.JoinRoomSuccess();
                    }));
                }
                else
                {
                    UnityMainThread.wkr.AddJob(new Action(() =>
                    {
                        OnlineGameController.Instance.JoinRoomFailed(result);
                    }));
                }
                break;
            case MessageCode.CREATE_ROOM_CODE:
                short idRoom = binaryReader.ReadInt16();
                UnityMainThread.wkr.AddJob(new Action(() =>
                {
                    OnlineGameController.Instance.CreateRoomSuccess(idRoom);
                }));
                break;
            case MessageCode.PLAYER_LEFT_AREROOM_CODE:
                UnityMainThread.wkr.AddJob(new Action(() =>
                {
                    OnlineGameController.Instance.PlayerLeftRoom();
                }));
                break;
            case MessageCode.SHOT_BULLET_CODE:
                byte type = binaryReader.ReadByte();
                UnityMainThread.wkr.AddJob(new Action(() =>
                {
                    PlayerNetworkController.Instance.AddNewShotBullet();
                }));
                break;
            default:
                Debug.Log("Command " + message.Command + " not found");
                break;
        }
    }
}
