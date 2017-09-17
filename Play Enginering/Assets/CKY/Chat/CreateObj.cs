using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateObj : MonoBehaviour {

    private Object curObject;
    private GameObject curObj;
    private AsyncOperation async = null;
    // Use this for initialization
    void Start() {
        
        curObject = Resources.Load("Model/" + "jiaolun", typeof(GameObject));
        curObj = Instantiate(curObject) as GameObject;
        curObj.transform.localScale = new Vector3(30, 30, 30);     
    }

    public void ChangeScene()
    {
        DontDestroyOnLoad(curObj);
        curObj.transform.localPosition = new Vector3(0, 0, 3);
        curObj.transform.localScale = new Vector3(10, 10, 10);
        Screen.orientation = ScreenOrientation.Landscape;
        StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {
        
        async = SceneManager.LoadSceneAsync("VRTest");
        yield return async;
        Debug.Log("VRTest");
    }
}
	
	

