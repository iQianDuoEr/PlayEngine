
using UnityEngine.UI;
using System.Collections.Generic;

namespace UIFrameWork
{
    public class ChatContext : BaseContext
    {
        public ChatContext() : base(UIType.Chat)
        {
        }
    }


    public class ChatView : EnableView
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

        //进入聊天模块
        public void ChatCallBack()
        {
            if (!GameManager.Instance.CanOperate())
                return;
            UIManager.Instance.Push(new ChatContext());
            UIManager.Instance.isQuit = true;
        }

    }
}
