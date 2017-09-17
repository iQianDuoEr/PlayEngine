using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour {

    //定义远程服务器IP（这里设置为本地）
    private string ip = "127.0.0.1";
    //定义服务器端口
    private int port = 10001;
    //限制连接数量为15个用户
    private int connectCount = 15;
    //是否启用网络地址转换器
    private bool useNAT = false;
    //接收到的消息
    private string recMes = "";
    //要发送的消息
    private string sendMes = "";

    void Start()
    {

    }

    void Update()
    {

    }

    void OnGUI()
    {
        switch (Network.peerType)
        {
            //服务器是否开启,没有与服务器连接时
            case NetworkPeerType.Disconnected:
                StartCreate();
                break;
            //启动服务器
            case NetworkPeerType.Server:
                OnServer();
                break;
            //启动客户端
            case NetworkPeerType.Client:
                OnClient();
                break;
            //尝试连接
            case NetworkPeerType.Connecting:
                Debug.Log("连接中");
                break;
        }
    }

    void StartCreate()
    {
        GUILayout.BeginVertical();
        //新建服务器连接
        if (GUILayout.Button("新建服务器"))
        {
            //初始化服务器端口，服务器创建成功后,Network.peerType变为NetworkPeerType.Server
            NetworkConnectionError error = Network.InitializeServer(connectCount, port, useNAT);
            Debug.Log(error);
        }
        //客户端是否连接服务器
        if (GUILayout.Button("连接服务器"))
        {
            //连接至服务器，与服务器连接成功后，Network.peerType变为NetworkPeerType.Client
            NetworkConnectionError error = Network.Connect(ip, port);
            Debug.Log(error);
        }
        GUILayout.EndVertical();
    }
    void OnServer()
    {
        GUILayout.Label("新建服务器成功，等待客户端连接");
        ////得到的IP与端口
        //string ip = Network.player.ipAddress;
        //int port = Network.player.port;
        //GUILayout.Label("IP地址:"+ip+".\n端口号:"+port);
        //连接到服务器的所有客户端
        int length = Network.connections.Length;
        //遍历所有客户端并获取IP与端口号
        for (int i = 0; i < length; i++)
        {
            GUILayout.Label("连接的IP:" + Network.connections[i].ipAddress);
            GUILayout.Label("连接的端口:" + Network.connections[i].port);
        }
        if (GUILayout.Button("断开连接"))
        {
            //从服务器上断开链接，断开连接之后，Network.peerType变为NetworkPeerType.Disconnected
            Network.Disconnect();
        }
        GUILayout.TextArea(recMes);
        sendMes = GUILayout.TextField(sendMes);
        if (GUILayout.Button("发送消息"))
        {
            //GetComponent<Network>().RPC("SendMes", RPCMode.All, Network.player + "Say:" + sendMes);
        }
    }

    void OnClient()
    {
        GUILayout.Label("连接成功");
        if (GUILayout.Button("断开连接"))
        {
            //断开连接后，Network.peerType变为NetworkPeerType.Disconnected
            Network.Disconnect();
        }
        GUILayout.TextArea(recMes);
        sendMes = GUILayout.TextField(sendMes);
        if (GUILayout.Button("发送消息"))
        {
            //GetComponent<Network>().RPC("SendMes",RPCMode.All,Network.player+"Say:"+sendMes);
        }
    }

    [RPC]
    void SendMes(string mes)
    {
        this.recMes += "\n";
        this.recMes += mes;
    }
}
