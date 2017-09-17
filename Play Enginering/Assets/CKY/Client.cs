using System.Collections;
using UnityEngine;

public class Client : MonoBehaviour {

    private string ip = "127.0.0.1";
    private int port = 1990;
    private string msg = "";
    private string otherMsg = "";

    void Start()
    {

    }

    void OnGUI()
    {
        switch (Network.peerType)
        {
            //禁止客户端连接运行，服务器未初始化
            case NetworkPeerType.Disconnected:
                if (GUI.Button(new Rect(10, 10, 100, 40), "连接服务器"))
                {
                    NetworkConnectionError error = Network.Connect(ip,port);
                }
                break;
            case NetworkPeerType.Server:
                break;
            //运行于客户端
            case NetworkPeerType.Client:
                msg = GUI.TextArea(new Rect(10, 10, 400, 300), msg, 300);
                if (GUI.Button(new Rect(10, 320, 100, 40), "发送信息"))
                {
                    //发送给接受的函数，模式为全部，参数为信息
                    GetComponent<NetworkView>().RPC("ReceiveMessage",RPCMode.Others,msg);
                    msg = "";
                }
                otherMsg = GUI.TextArea(new Rect(430, 10, 400, 300), otherMsg, 300);
                break;
            //正在尝试连接到服务器
            case NetworkPeerType.Connecting:
                break;
        }
    }

    //接收请求的方法，注意要在上面添加[RPC]
    [RPC]
    void ReceiveMessage(string msg, NetworkMessageInfo info)
    {
        //刚从网络接受的数据的相关信息，会被保存到NetworkMessageInfo这个结构中
        otherMsg = info.sender.ipAddress + "用户:" + msg;
    }
}
