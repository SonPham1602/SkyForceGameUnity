using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MessageWriter
{
    public static Message getMessagesHansake()
    {
        return new Message()
        {
            Command = MessageCode.HANSAKE_CODE
        };
    }

    public static Message getMessageChangePosition(byte direction, Vector3 position)
    {
        byte[] dataX = BitConverterMapping.GetBytes(position.x);
        byte[] dataY = BitConverterMapping.GetBytes(position.y);

        byte[] data = new byte[1 + dataX.Length + dataY.Length];
        data[0] = direction;
        dataX.CopyTo(data, 1);
        dataY.CopyTo(data, 1 + dataX.Length);

        return new Message()
        {
            Command = MessageCode.CHANGE_POSITION_CODE,
            Data = data,
        };
    }

    public static Message registerPlayer(String username)
    {
        byte[] data1 = Encoding.UTF8.GetBytes(username);
        byte[] dataSize1 = BitConverterMapping.GetBytes((short)username.Length);

        byte[] data = new byte[data1.Length + dataSize1.Length];
        dataSize1.CopyTo(data, 0);
        data1.CopyTo(data, dataSize1.Length);
        return new Message()
        {
            Command = MessageCode.REGISTER_PLAYER,
            Data = data,
        };
    }

    public static Message getPlayerInRoomMessage() {
        return new Message()
        {
            Command = MessageCode.GET_PLAYER_IN_ROOM,
            Data = null,
        };
    }

     public static Message getShotBulletMessage(byte type) {
        return new Message()
        {
            Command = MessageCode.SHOT_BULLET_CODE,
            Data = new byte[1] {type},
        };
    }

    public static Message getMessageJoinRoom(short roomId) {
        byte[] data = BitConverterMapping.GetBytes(roomId);
        return new Message()
        {
            Command = MessageCode.JOIN_ROOM_CODE,
            Data = data,
        };
    }

    public static Message createRoomMessage() {
        return new Message()
        {
            Command = MessageCode.CREATE_ROOM_CODE,
            Data = null,
        };
    }

    public static Message getWinGameMessage() {
        return new Message()
        {
            Command = MessageCode.WIN_GAME,
            Data = new byte[1] {0},
        };
    }
}
