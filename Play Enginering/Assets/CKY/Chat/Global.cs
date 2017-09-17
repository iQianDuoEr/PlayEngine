using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    public static Global Goinstance;

    static Global()
    {
        GameObject go = new GameObject("Globa");
        DontDestroyOnLoad(go);
        Goinstance = go.AddComponent<Global>();
    }

    public void DoSomeThings()
    {
        Debug.Log("DoSomeThings");
    }

    void Start()
    {
        Debug.Log("Start");
    }
}
