
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrameWork
{
    public class FindContext : BaseContext
    {
        public FindContext() : base(UIType.Find)
        {
        }
    }


    public class FindView : EnableView
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

        //进入发现模块
        public void FindCallBack()
        {
            if (!GameManager.Instance.CanOperate())
                return;
            UIManager.Instance.Push(new FindContext());
            UIManager.Instance.isQuit = true;
            
        }


    }
}
