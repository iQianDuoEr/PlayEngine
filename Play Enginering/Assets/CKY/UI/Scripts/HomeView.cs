
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



namespace UIFrameWork
{
    public class HomeContext : BaseContext
    {
        public HomeContext() : base(UIType.Home)
        {

        }
    }

    public class HomeView : BaseView
    { 

        public override void OnEnter(BaseContext context)
        {
            base.OnEnter(context);
            UIManager.Instance.isQuit = false;
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
            UIManager.Instance.isQuit = false;
        }
        public override void Excute()
        {
            base.Excute();
            //轮播图
            //。。。。
        }

        //重新进入主页树并清空之前的状态
        public void AccessToHomeMenu()
        {
            UIManager.Instance.StartAndResetUILine(UIManager.UILine.HomeMenu);
            UIManager.Instance.Push(new HomeContext());
        }
    }
}
