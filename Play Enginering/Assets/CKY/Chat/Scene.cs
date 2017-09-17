using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

    private Object go;
    private GameObject goInstance;

    void Start()
    {
        go = Resources.Load("Model/" + VRView.ObjName, typeof(GameObject));
        goInstance = Instantiate(go) as GameObject;
        goInstance.transform.localPosition = new Vector3(0, 0, 3);
        goInstance.transform.localScale = new Vector3(1, 1, 1);
    }
    // Use this for initialization
    public void PressBack()
    {
        StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {
        VRView.ObjName = null;
        AsyncOperation async = SceneManager.LoadSceneAsync("123");
        yield return async;
        Debug.Log("VRTest");
    }
}
