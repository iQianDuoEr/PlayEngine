

using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrameWork
{
    public class BookContext : BaseContext
    {
        public BookContext() : base(UIType.Book)
        {
        }
    }


    public class BookView : EnableView
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

        //进入教材模块
        public void BookCallBack()
        {
            if (!GameManager.Instance.CanOperate())
                return;
            UIManager.Instance.Push(new BookContext());
            UIManager.Instance.isQuit = true;
            
        }
    }
}
