using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Client:BaseManager
{

    public Client(GameFacade facade) : base(facade) { }


    private const string address = "127.0.0.1";
    private const int port = 8023;
    private Socket clientSocket;
    private Message message = new Message();
    public override void OnInit() {
        clientSocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(address, port);
            Start();
        }
        catch (System.Exception e) {
            Debug.LogError("无法连接服务端"+e);
        }

    }

    private void Start() {
        clientSocket.BeginReceive(message.data,message.StartIndex,message.RemainSize, SocketFlags.None, ReceivedCallBack,null);
    }

    private void ReceivedCallBack( IAsyncResult asyncResult) {
        try {
            int count = clientSocket.EndReceive(asyncResult);
            message.ReadMessage(count, HandlerMessage);
            Start();
        } catch (Exception e) {
            Debug.LogError("EndReceive:"+e);
        }
    }

    public void HandlerMessage(UInt64 messageId, byte[] data) {

        gameFacade.HandleResponse(messageId, data);
    }

    public void SendRequest(uint messageId,byte[] data) {
      byte[] sendData=  packer.packData(messageId, data);
        clientSocket.Send(sendData);

    }

    public override void OnDestroy() {
        try
        {
            clientSocket.Close();
        }
        catch (System.Exception e)
        {
            Debug.LogError("关闭连接" + e);
        }

    }

}
