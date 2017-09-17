using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatServer : MonoBehaviour {

    public int listenPort = 25000;
    private string playerMsgFromDisconnect = "";
    private string msgFromClient = "已经初始化服务器";
    private bool isStartServer = false;
    private bool flag = false;

    //启动服务器
    public void StartServer()
    {
        Network.InitializeServer(32, listenPort, false);
        isStartServer = true;
    }

    //服务器安装好之后显示的信息
    void OnServerInitialized()
    {
        //显示服务器的端口号和IP地址
        //显示已经连接的用户的IP地址和端口号
    }

    //接受请求的方法，注意要在上面添加[RPC]
    [RPC]
    void ReciveMessage(string msg, NetworkMessageInfo info)
    {
        //刚从网络接受的数据的相关信息，会被保存到NetworkMessageInfo这个结构中
        msgFromClient = info.sender.ipAddress + "用户：" + msg;
    }

    //链接上服务器之后显示连接成功
    void OnConnectedToServer()
    {

    }

    //当用户从服务器断开，从服务器调用这个函数
    void OnPlayerDisconnected(NetworkPlayer player)
    {
        playerMsgFromDisconnect = player.ipAddress + "断开连接";
        msgFromClient = playerMsgFromDisconnect;
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
    }


    //断线之后重新启动程序
    void OnDisconnectedFromServer()
    {
        if (this.enabled != false)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    
}
