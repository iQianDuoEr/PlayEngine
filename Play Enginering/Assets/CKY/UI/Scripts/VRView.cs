using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;

namespace UIFrameWork
{
    public class VRContext : BaseContext
    {
        public VRContext() : base(UIType.VR)
        {
        }
    }


    public class VRView : EnableView
    {

        public static string ObjName;
       

        public override void Init()
        {
            base.Init();
        }
        public override void OnEnter(BaseContext context)
        {
            base.OnEnter(context);
            ObjName = null;
        }
        public override void OnExit(BaseContext context)
        {
            base.OnExit(context);
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
#if UNITY_EDITOR || UNITY_EDITOR_WIN
            GetModelOnWin();
#elif UNITY_ANDROID
		    //GetModelOnAndroid();
            GetModelOnWin();                       
#endif
        }

        //进入VR模块
        public void VRCallBack()
        {
            if (!GameManager.Instance.CanOperate())
                return;
            UIManager.Instance.Push(new VRContext());
            UIManager.Instance.isQuit = true;
        }

        public void GetModelOnWin()
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                if (ObjName == null )
                {
                    switch (EventSystem.current.currentSelectedGameObject.name)
                    {
                        case "Tog_Simple":
                            break;
                        case "Tog_JD":
                            break;
                        case "Tog_XG":
                            break;
                        case "Tog_ZH":
                            break;
                        case "Btn_Back":
                            break;
                        default:
                            ObjName = EventSystem.current.currentSelectedGameObject.name;
                            //ControlView.DObject.AddOrReplace(ObjName,"ready");
                            break;
                    }
                }
            }
        }

        public void GetModelOnAndroid()
        {
            if (Input.touchCount != 1)
                return;

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if (Physics.Raycast(ray, out hit))
                {
                    Object curObject2 = Resources.Load("Model/" + "yuanzhui", typeof(GameObject));
                    GameObject curObj2 = Instantiate(curObject2) as GameObject;
                    curObj2.transform.localScale = new Vector3(30, 30, 30);
                    Debug.Log(hit.transform.name);
                    if (ObjName == null)
                    {
                        ObjName = hit.transform.name;
                        Debug.Log(ObjName);
                    }
                }
            }
        }
    }
}

