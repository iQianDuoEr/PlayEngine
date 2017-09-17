
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace UIFrameWork
{
    public class WorkContext : BaseContext
    {
        public WorkContext() : base(UIType.Work)
        {
        }
    }


    public class WorkView : EnableView
    {

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

        //进入模型模块
        public void WorkCallBack()
        {
            if (!GameManager.Instance.CanOperate())
                return;
            UIManager.Instance.Push(new WorkContext());
            UIManager.Instance.isQuit = true;
        }
    }
}
