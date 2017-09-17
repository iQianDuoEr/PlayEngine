using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

namespace UIFrameWork
{
    public class ButtonContext : BaseContext
    {
       public ButtonContext() : base(UIType.Button)
       {
            
       }
    }

    public class ButtonView : ControlView
    {
        public static Dictionary<string, bool> DXing = new Dictionary<string, bool>();
        public Toggle TXing;

        public GameObject ModelTexture;
        public GameObject WorkText;

        public override void Init()
        {
            base.Init();
        }
        public override void OnEnter(BaseContext context)
        {
            base.OnEnter(context);  
        }
       public override void OnExit(BaseContext context)
       {
            base.OnExit(context);
            TXing.isOn = false;
        }
        public override void OnPause(BaseContext context)
        {
            base.OnPause(context);
        }
       public override void OnResume(BaseContext context)
        {
            base.OnResume(context);
        }

       public override void Excute()
       {
            base.Excute();
       }

        public void ClickButton()
        {
            if (!GameManager.Instance.CanOperate())
                return;
            UIManager.Instance.Push(new ButtonContext());
            UIManager.Instance.isQuit = true;
        }

        public void ToggleOn()
        {
            if(TXing.isOn==true)
                DXing.TryAdd(VRView.ObjName,TXing.isOn);
        }

        //切换场景
        public void ChangeScene()
        {
            Screen.orientation = ScreenOrientation.Landscape;
            StartCoroutine("LoadScene");
        }

        IEnumerator LoadScene()
        {
            AsyncOperation async = SceneManager.LoadSceneAsync("VRTest");
            yield return async;
            Debug.Log("VRTest");
        }

        //重置按钮
        public void ResetModel()
        {
            curObj.transform.localScale = new Vector3(3, 3, 3);
            curObj.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //展示三视图按钮
        public void ShowTexture()
        {
            string str = VRView.ObjName;
            if (VRView.ObjName != null)
            {
                Sprite curSpt = Resources.Load<Sprite>("Texture/" + str);
                ModelTexture.GetComponent<Image>().sprite = curSpt;
                ModelTexture.SetActive(true);
            }
            //curSprite = Resources.Load("Texture/" + VRView.ObjName, typeof(Sprite));
            //curSpt = Instantiate(curObject) as Sprite;
            //Texture.sprite = curSpt;
            //Texture.gameObject.SetActive(true);
        }

        //展示习题按钮
        public void ShowWork()
        {
            string str = VRView.ObjName;
            WorkText.SetActive(true);
            if (VRView.ObjName != null)
            {
                Sprite curSpt = Resources.Load<Sprite>("Texture/" + str);
                ModelTexture.GetComponent<Image>().sprite = curSpt;
                ModelTexture.SetActive(true);
            }
        }
    }
}
