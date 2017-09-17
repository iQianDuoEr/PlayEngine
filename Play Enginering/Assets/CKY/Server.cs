
using System.Collections;
using UnityEngine;

public class Server : MonoBehaviour {

    //端口号
    private int connectPort = 1990;
    private Vector2 scrollPosition = Vector2.zero;

    private string playerMsgFromDisconnect = "";

    private string msgFromClient = "已经初始化服务器";
    private bool isStartServer = false;
    private bool flag = false;

    void OnGUI()
    {
        if (isStartServer)
        {
            GUI.Label(new Rect(10, 20, 400, 100), msgFromClient);

            scrollPosition = GUI.BeginScrollView(new Rect(10, 120, 600, 480)
                , scrollPosition, new Rect(0,0, 550, 50 * Network.connections.Length));
            for (int i = 0; i < Network.connections.Length; i++)
            {
                GUI.Label(new Rect(10, 45 * i + 10, 500, 40), Network.connections[i].ipAddress + "已连接");
            }
            GUI.EndScrollView();
        }
        else
        {
            //初始化多人在先服务器
            if (GUI.Button(new Rect(10, 10, 100, 60), "创建服务器"))
            {
                Network.InitializeServer(32, connectPort, false);
                isStartServer = true;
            }
        }
    }
    //当用户从服务器断开，从服务器调用这个函数
    void OnPlayerDisconnected(NetworkPlayer player)
    {
        playerMsgFromDisconnect = player.ipAddress + "断开连接";
        msgFromClient = playerMsgFromDisconnect;
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
    }

    //接受请求的方法，注意要在上面添加[RPC]
    [RPC]
    void ReciveMessage(string msg, NetworkMessageInfo info)
    {
        //刚从网络接受的数据的相关信息，会被保存到NetworkMessageInfo这个结构中
        msgFromClient = info.sender.ipAddress + "用户：" + msg;
    }
}
