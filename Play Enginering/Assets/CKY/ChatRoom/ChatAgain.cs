using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatAgain : MonoBehaviour {

    public string remoteIP = "123.207.138.169";
    public int remotePort = 25000;
    public int listenPort = 25000;
    private string connectionInfo = "";
    string MyName = "";
    string Inputword = "";
    string OutputWord = "";

    void OnGUI()
    {
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            GUILayout.BeginVertical();
            if (GUILayout.Button("Connect"))
            {
                Network.Connect(remoteIP, remotePort);
            }
            if (GUILayout.Button("StartServer"))
            {
                Network.InitializeServer(32, listenPort, false);
            }
            GUILayout.EndVertical();
            remoteIP = GUILayout.TextField(remoteIP, GUILayout.MinWidth(145));
            remotePort = int.Parse(GUILayout.TextField(remotePort.ToString()));
        }
        else
        {
            if (Network.isServer)
            {
                GUI.Label(new Rect(30, 12, 500, 30), "Server Local IP/Port:" + Network.player.ipAddress + "/" + Network.player.port);
                GUI.Label(new Rect(30, 24, 500, 30), "Server External IP/Port:" + Network.player.externalIP + "/" + Network.player.port);
            }
            if (GUI.Button(new Rect(300, 0, 100, 30), "Disconnect"))
            {
                Network.Disconnect(200);
            }
            GUI.Label(new Rect(30, 50, 100, 30), "Name");
            MyName = GUI.TextField(new Rect(70, 48, 100, 30), MyName,10);
            OutputWord = GUI.TextArea(new Rect(30, 80, 400, 300), OutputWord, 1000);
            Inputword = GUI.TextField(new Rect(30, 400, 300, 60), Inputword, 200);
            if (GUI.Button(new Rect(350, 400, 70, 60), "send"))
            {
                GetComponent<NetworkView>().RPC("SomeoneSay", RPCMode.All, Inputword, MyName);
                Inputword = "";
            }
        }
    }


    void OnServerInitialized()
    {
        Debug.Log("==>Local IP/Port is "+Network.player.ipAddress+"/"+Network.player.port);
    }

    void OnConnectedToServer()
    {
        Debug.Log("Connected!!!");
    }

    void OnDisconnectedFromServer()
    {
        if (this.enabled != false)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    [RPC]
    void SomeoneSay(string message, string name)
    {
        OutputWord = OutputWord + "\n" + name + ": " + message;
    }
}
