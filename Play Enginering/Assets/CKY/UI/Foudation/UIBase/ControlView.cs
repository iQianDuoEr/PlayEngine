using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UIFrameWork
{
    public abstract class ControlView : BaseView
    {
        protected Object curObject;
        protected GameObject curObj;


        public float rotateSpeed = 250f;
        public bool isRoteteSelf = false;
        public bool isDragMove = false;

        private CanvasGroup _canvasGroup;
        public override void Init()
        {
            base.Init();
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        public override void OnEnter(BaseContext context)
        {
            base.OnEnter(context);
            gameObject.SetActive(true);
            if (VRView.ObjName != null)
            {
                curObject = Resources.Load("Model/" + VRView.ObjName, typeof(GameObject));
                curObj = Instantiate(curObject) as GameObject;
                curObj.transform.localScale = new Vector3(3, 3, 3);
            }
        }
        public override void OnExit(BaseContext context)
        {
            base.OnExit(context);
            gameObject.SetActive(false);
            Destroy(curObj);
            VRView.ObjName = null;
        }
        public override void OnPause(BaseContext context)
        {
            base.OnPause(context);
            _canvasGroup.blocksRaycasts = false;
        }
        public override void OnResume(BaseContext context)
        {
            base.OnResume(context);
            _canvasGroup.blocksRaycasts = true;
        }
        public override void Excute()
        {
            base.Excute();

            if (curObj != null)
            {
                #if UNITY_EDITOR || UNITY_EDITOR_WIN
                                RotateOnWin();
                                ScaleOnWin();
                #elif UNITY_ANDROID
		                RotateOnMobile();
		                ScaleOnMobile();
                #endif
            }
        }


        void RotateOnWin()
        {
            if (!isDragMove && !isRoteteSelf )
            {
                float horizontal = Input.GetAxis("Mouse X");
                float vertical = Input.GetAxis("Mouse Y");
                Vector3 moveAxis = new Vector3(horizontal, vertical, 0f);
                Vector3 rotateAxis = Vector3.Cross(moveAxis, Vector3.forward);

                curObj.transform.Rotate(rotateAxis, rotateSpeed * Time.deltaTime, Space.World);
            }


        }


        void ScaleOnWin()
        {
            if (!isDragMove && !isRoteteSelf )
            {
                float scaleValue = Input.GetAxis("Mouse ScrollWheel");

                if (scaleValue > 0)
                {
                    curObj.transform.localScale *= 1.1f;
                }

                if (scaleValue < 0)
                {
                    curObj.transform.localScale *= 0.9f;
                }

            }
        }


        /// <summary>
        /// Rotates the on mobile.手机上的旋转
        /// </summary>
        void RotateOnMobile()
        {
            if (!isDragMove && !isRoteteSelf )
            {
                if (Input.touchCount > 0 && TouchPhase.Moved == Input.GetTouch(0).phase)
                {
                    Vector2 figerVec = Input.GetTouch(0).deltaPosition;
                    Vector3 moveAxis = new Vector3(figerVec.x, figerVec.y, 0);

                    Vector3 rotateAxis = Vector3.Cross(moveAxis, Camera.main.transform.forward);

                    curObj.transform.Rotate(rotateAxis, rotateSpeed * Time.deltaTime, Space.World);
                }
            }
        }



        Vector2 foreVec = Vector2.zero;
        Vector2 laterVec = Vector2.zero;
        /// <summary>
        /// Scales the on mobile.手机上的缩放
        /// </summary>
        void ScaleOnMobile()
        {
            if (!isDragMove && !isRoteteSelf)
            {
                if (Input.touchCount == 2)
                {
                    Touch figer1 = Input.GetTouch(0);
                    Touch figer2 = Input.GetTouch(1);
                    if (figer1.phase == TouchPhase.Stationary && figer2.phase == TouchPhase.Stationary)
                    {
                        foreVec = figer1.position - figer2.position;
                    }
                    if (figer1.phase == TouchPhase.Moved || figer2.phase == TouchPhase.Moved)
                    {
                        laterVec = figer1.position - figer2.position;
                        if (foreVec.sqrMagnitude > laterVec.sqrMagnitude)
                        {
                            curObj.transform.localScale *= 0.95f;
                        }
                        else if (foreVec.sqrMagnitude < laterVec.sqrMagnitude)
                        {
                            curObj.transform.localScale *= 1.05f;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }


        
    }
}
