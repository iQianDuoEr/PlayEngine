using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatClient : MonoBehaviour {

    public string remoteIP = "123.207.138.169";
    public int remotePort = 25000;

    private string connectionInfo = "";
    string MyName = "";
    string Inputword = "";
    string OutputWord = "";

    public InputField Name;
    public InputField SendInfo;
    public InputField DisplayInfo;
    public Button Connect;
    public Button Send;

    //按下按钮客户端连接服务器
    public void ConnectServer()
    {
        MyName = Name.text;
        Name.gameObject.SetActive(false);
        Connect.gameObject.SetActive(false);
        Send.gameObject.SetActive(true);
        SendInfo.gameObject.SetActive(true);
        DisplayInfo.gameObject.SetActive(true);
        Network.Connect(remoteIP, remotePort);
        Debug.Log("连接服务器");
    }

    //按下发送信息的按钮
    public void SendMessage()
    {
        Inputword = SendInfo.text;
        SendInfo.text = "";
        GetComponent<NetworkView>().RPC("SomeoneSay", RPCMode.All, Inputword, MyName);
        Debug.Log("发送信息");
    }

    //按下断开连接的按钮
    public void DisconnectServer()
    {
        Network.Disconnect(200);
    }

    [RPC]
    void SomeoneSay(string message,string MyName)
    {
        OutputWord = OutputWord + "\n" + MyName + ":" + message;
        //刚从网络接受的数据的相关信息，会被保存到NetworkMessageInfo这个结构中
       // OutputWord = info.sender.ipAddress + "用户:" + message;
        Debug.Log(message+MyName);
    }
}
