using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UIFrameWork
{
    public class UIManager : Singleton<UIManager>
    {
        public enum UILine
        {
            HomeMenu,
            MarkMenu,
            PersonMenu
        }
        public UIContext activeContext;
        public Dictionary<UILine, UIContext> _UILineDic = new Dictionary<UILine, UIContext>();
        public Dictionary<UIType, GameObject> _UIDic = new Dictionary<UIType, GameObject>();

        private Transform _canvas;
        public bool isQuit = false;

        public delegate void UIFunc();
        public Queue<UIFunc> funcQueue = new Queue<UIFunc>();

        public bool isBlackTrans=false;

        private UIManager()
        {
            _canvas = GameObject.Find("Canvas").transform;
            foreach (Transform item in _canvas)
            {
                GameObject.Destroy(item.gameObject);
            }
        }

        public void Push(BaseContext nextContext)
        {
            if (isBlackTrans)
            {
                funcQueue.Enqueue(delegate (){ Push(nextContext); });
                return;
            }
            activeContext.Push(nextContext);
        }
        public void Pop()
        {
            if(isBlackTrans)
            {
                funcQueue.Enqueue(delegate() { Pop(); });
                return;
            }
            activeContext.Pop();
        }
        public void StartUILine(UILine line)
        {
            if (isBlackTrans)
            {
                funcQueue.Enqueue(delegate() { StartUILine(line); });
                return;
            }
            if (activeContext != null)
            {
                activeContext.LineExit();
            }
            if (!_UILineDic.ContainsKey(line))
            {
                _UILineDic.Add(line, new UIContext());
            }
            activeContext = _UILineDic[line];
            activeContext.LineStart();
        }
        public void StartAndResetUILine(UILine line)
        {
            if (isBlackTrans)
            {
                funcQueue.Enqueue(delegate () { StartAndResetUILine(line); });
                return;
            }
            if (activeContext != null)
            {
                activeContext.LineExit();
            }
            _UILineDic.AddOrReplace(line, new UIContext());
            activeContext = _UILineDic[line];
        }
        public GameObject GetSingleUI(UIType uiType)
        {
            if (_UIDic.ContainsKey(uiType) == false || _UIDic[uiType] == null)
            {
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(uiType.Path)) as GameObject;
                go.transform.SetParent(_canvas, false);
                go.name = uiType.Name;
                _UIDic.AddOrReplace(uiType, go);
                go.GetComponent<BaseView>().Init();
                return go;
            }
            return _UIDic[uiType];
        }
        public void DestorySingleUI(UIType uiType)
        {
            if (!_UIDic.ContainsKey(uiType))
            { return; }
            if (_UIDic[uiType] == null)
            {
                _UIDic.Remove(uiType);
                return;
            }
            GameObject.Destroy(_UIDic[uiType]);
            _UIDic.Remove(uiType);
        }

        public void StartBlackTrans()
        {
            isBlackTrans = true;
        }

        public void Update()
        {
            
        }
    }
}