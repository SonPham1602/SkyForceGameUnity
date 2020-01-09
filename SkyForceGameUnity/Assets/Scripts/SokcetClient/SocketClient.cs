using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class SocketClient : MonoBehaviour
{
    public static SocketClient Instance;
    private TcpClient socketConnection;
    private Thread clientReceiveThread;
    private List<Message> Messages;

    private String host = "34.87.115.224";
    
    [SerializeField]
    private int port = 1234;

    void Start()
    {
        Instance = this;
        Messages = new List<Message>();
        ConnectToTcpServer();
    }

    void Update()
    {
        if (Messages.Count > 0)
        {
            Message ms = Messages[0];
            SendMessage(ms);
            Messages.RemoveAt(0);
        }
    }

    private void ConnectToTcpServer()
    {
        try
        {
            socketConnection = new TcpClient();
            socketConnection.Connect(host, port);

            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
            socketConnection.Close();
            socketConnection = null;
            UnityMainThread.wkr.AddJob(new System.Action(() =>
            {
                // NotifyManagement.Instance.ShowNotifyMessage("Mất kết nối tới server");
            }));
        }

        SendHansakeMessage();
    }

    private void ListenForData()
    {
        try
        {
            while (socketConnection != null)
            {
                // Get a stream object for reading 				
                NetworkStream stream = socketConnection.GetStream();
                var reader = new BinaryReaderConverter(stream);
                // Read incomming stream into byte arrary. 	
                byte command = reader.ReadByte();
                byte length1 = reader.ReadByte();
                byte length2 = reader.ReadByte();
                int length = length1 * 256 + length2;

                Message message = new Message() { Command = command };

                if (length != 0)
                {
                    byte[] data = reader.ReadBytes(length);
                    message.Data = data;
                } else {
                    message.Data = new byte[0];
                }
                MessageHandler.onMessage(message);
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
            socketConnection.Close();
            socketConnection = null;
            UnityMainThread.wkr.AddJob(new System.Action(() =>
            {
                // NotifyManagement.Instance.ShowNotifyMessage("Mất kết nối tới server");
            }));
        }
    }

    private void SendMessage(Message message)
    {
        if (socketConnection == null)
        {
            return;
        }
        
        try
        {
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                stream.WriteByte((byte)message.Command);
                if (message.Data != null)
                {
                    int size = message.Data.Length;
                    stream.WriteByte((byte)(size / 256));
                    stream.WriteByte((byte)(size % 256));
                    stream.Write(message.Data, 0, size);
                }
                else
                {
                    stream.WriteByte(0);
                    stream.WriteByte(0);
                }
                stream.Flush();
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
            socketConnection.Close();
            socketConnection = null;
            UnityMainThread.wkr.AddJob(new System.Action(() =>
            {
                // NotifyManagement.Instance.ShowNotifyMessage("Mất kết nối tới server");
            }));
        }
    }

    public void AddMessage(Message message)
    {
        Messages.Add(message);
    }

    private void SendHansakeMessage()
    {
        SendMessage(MessageWriter.getMessagesHansake());
    }

    void OnDestroy()
    {
        if (socketConnection.Connected)
        {
            socketConnection.Close();
        }
    }
}
